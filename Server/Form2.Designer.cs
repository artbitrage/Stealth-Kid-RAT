namespace RemoteServer
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.matrixText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // matrixText
            // 
            this.matrixText.BackColor = System.Drawing.SystemColors.InfoText;
            this.matrixText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixText.Font = new System.Drawing.Font("Lucida Console", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matrixText.ForeColor = System.Drawing.Color.LimeGreen;
            this.matrixText.Location = new System.Drawing.Point(0, 1);
            this.matrixText.Multiline = true;
            this.matrixText.Name = "matrixText";
            this.matrixText.ReadOnly = true;
            this.matrixText.Size = new System.Drawing.Size(284, 263);
            this.matrixText.TabIndex = 0;
            this.matrixText.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.ControlBox = false;
            this.Controls.Add(this.matrixText);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "You\'ve Been Hacked By DT";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Leave += new System.EventHandler(this.Form2_Leave);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox matrixText;



    }
}