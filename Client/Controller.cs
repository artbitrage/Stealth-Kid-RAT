using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Controller : Form
    {
        private Screen client;

        //private Thread iThread;
        private TcpClient connector;

        private Thread animateFunButton;
        private bool hasBlackScreen = false;

        public Controller()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            showDisconnect();
            /*iThread = new Thread(new ThreadStart(startConnect));
            iThread.Start();*/
            startConnect();
        }

        private void startConnect()
        {
            try
            {
                connector = new TcpClient(ipAddress.Text.ToString(), int.Parse(port.Text.ToString()));
                trackBar1.Enabled = true;
                trackBar1.Show();
                mouseAndKeyboard.Enabled = true;
                mouseAndKeyboard.Show();
                this.Height = 283;
                client = new Screen(connector, this);
                client.Show();
            }
            catch (Exception problem)
            {
                MessageBox.Show("Invalid IPAddress, Invalid Port, Failed Internet Connection, or Cannot connect to client for some reason ; ;\nOdds are you're an idiot ^.- double check what you entered n00b\n\nTechnical Data:\n**************************************************\n" + problem.ToString(), "You're a Failure!");
                showConnect();
            }
        }

        private void showConnect()
        {
            ipAddress.ReadOnly = false;
            port.ReadOnly = false;
            disconnectButton.Hide();
            disconnectButton.Enabled = false;
            connectButton.Show();
            connectButton.Enabled = true;
            trackBar1.Enabled = false;
            trackBar1.Hide();
            mouseAndKeyboard.Enabled = false;
            mouseAndKeyboard.Hide();
            mouseAndKeyboard.ForeColor = Color.Red;
            mouseAndKeyboard.Text = "Takeover Mouse And Keyboard";
            blackScreen.Text = "Black Screen";
            hasBlackScreen = false;
            this.Width = 202;
            this.Height = 124;
        }

        private void coolButton()
        {
            while (true)
            {
                Random rand = new Random();
                funButton.ForeColor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                Thread.Sleep(100);
            }
        }

        private void showDisconnect()
        {
            ipAddress.ReadOnly = true;
            port.ReadOnly = true;
            connectButton.Hide();
            connectButton.Enabled = false;
            disconnectButton.Show();
            disconnectButton.Enabled = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.Environment.Exit(0);
            if (animateFunButton.IsAlive)
                animateFunButton.Abort();
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //disconnectButton.Enabled = false;
            //disconnectButton.Hide();
            showConnect();
            this.MaximizeBox = false;
            animateFunButton = new Thread(new ThreadStart(coolButton));
            animateFunButton.Start();
            matrixInput.Visible = false;
            matrixInput.Enabled = false;
            blackScreenLabel.Visible = false;
        }

        public void screenClosed()
        {
            if (client.Visible)
                client.Dispose();
            connector.Close();
            showConnect();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (client.Visible)
                client.Dispose();
            connector.Close();
            showConnect();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            client.imageDelayChange(trackBar1.Value);
            imageDelayLabel.Text = ((float)trackBar1.Value / 1000).ToString();
        }

        private void mouseAndKeyboard_Click(object sender, EventArgs e)
        {
            if (!client.sendKeysAndMouse)
            {
                mouseAndKeyboard.ForeColor = Color.Green;
                mouseAndKeyboard.Text = "Release Mouse And Keyboard";
                client.sendKeysAndMouse = true;
            }
            else
            {
                mouseAndKeyboard.ForeColor = Color.Red;
                mouseAndKeyboard.Text = "Takeover Mouse And Keyboard";
                client.sendKeysAndMouse = false;
            }
        }

        private void ipAddress_KeyUp(object sender, KeyEventArgs e)
        {
            //For Debugging Keyboard
            //MessageBox.Show(e.KeyCode.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult reallyShutdown = MessageBox.Show("!! WARNING !!\n\nShutting down the server will leave you unable to reconnect until " +
                            "the computer restarts (IF The server is set to run on Startup). You will be unable " +
                            "to reconnect until this occurs.\n\nARE YOU SURE YOU WANT TO SHUTDOWN THE SERVER?", "!! WARNING !!", MessageBoxButtons.YesNo);
            if (reallyShutdown == DialogResult.Yes)
                client.sendShutdown();
            return;
        }

        private void funButton_Click(object sender, EventArgs e)
        {
            if (this.Width != 412)
                this.Width = 412;
            else
                this.Width = 202;
        }

        private void blackScreen_Click(object sender, EventArgs e)
        {
            if (!hasBlackScreen)
            {
                client.sendBlackScreen();
                blackScreen.Text = "Remove";
                hasBlackScreen = true;
                matrixInput.Visible = true;
                matrixInput.Enabled = true;
                blackScreenLabel.Visible = true;
            }
            else
            {
                client.hideBlackScreen();
                blackScreen.Text = "Black Screen";
                hasBlackScreen = false;
                matrixInput.Visible = false;
                matrixInput.Enabled = false;
                blackScreenLabel.Visible = false;
            }
        }

        private void matrixInput_TextChanged(object sender, EventArgs e)
        {
            client.sendMatrixText(matrixInput.Text.ToString());
        }

        private void beep_Click(object sender, EventArgs e)
        {
            client.sendBeep(1);
        }
    }
}