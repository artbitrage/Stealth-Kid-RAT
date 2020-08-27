using System;
using System.Windows.Forms;

namespace RemoteServer
{
    public partial class Debuggy : Form
    {
        public Debuggy()
        {
            InitializeComponent();
        }

        private void Debuggy_Load(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
            this.Focus();
        }
    }
}