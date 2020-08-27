using System;
using System.Windows.Forms;

//using System.Runtime.InteropServices;

namespace RemoteServer
{
    public partial class Form2 : Form
    {
        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //public static extern void SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int X, int Y, int width, int height, uint flags);

        private int screenWidth;
        private int screenHeight;

        //private Thread ownage;
        public Form2()
        {
            InitializeComponent();
            screenWidth = 1024;
            screenHeight = 768;
        }

        public Form2(int x, int y)
        {
            InitializeComponent();
            screenWidth = x;
            screenHeight = y;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            //ownage = new Thread(new ThreadStart(doOwnage));
            //ownage.Start();
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            //SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, screenWidth, screenHeight, 64);
            //textBox1.Width = this.Width;
            //textBox1.Height = this.Height;
            matrixText.Width = this.Width;
            matrixText.Height = this.Height;
        }

        //private void doOwnage() {
        //  while(true) {
        //    Cursor.Position = new Point(0,0);

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            //textBox1.Width = this.Width;
            //textBox1.Height = this.Height;
        }

        private void Form2_Leave(object sender, EventArgs e)
        {
            this.TopLevel = true;
        }
    }
}