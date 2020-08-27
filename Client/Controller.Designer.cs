namespace Client
{
    partial class Controller
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.mouseAndKeyboard = new System.Windows.Forms.Button();
            this.imageDelayLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.funButton = new System.Windows.Forms.Button();
            this.blackScreen = new System.Windows.Forms.Button();
            this.matrixInput = new System.Windows.Forms.TextBox();
            this.blackScreenLabel = new System.Windows.Forms.Label();
            this.beep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // ipAddress
            // 
            this.ipAddress.BackColor = System.Drawing.SystemColors.InfoText;
            this.ipAddress.ForeColor = System.Drawing.Color.OrangeRed;
            this.ipAddress.Location = new System.Drawing.Point(76, 9);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(100, 20);
            this.ipAddress.TabIndex = 2;
            this.ipAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ipAddress_KeyUp);
            // 
            // port
            // 
            this.port.BackColor = System.Drawing.SystemColors.InfoText;
            this.port.ForeColor = System.Drawing.Color.OrangeRed;
            this.port.Location = new System.Drawing.Point(76, 34);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 20);
            this.port.TabIndex = 3;
            // 
            // connectButton
            // 
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Location = new System.Drawing.Point(12, 60);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(164, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectButton.Location = new System.Drawing.Point(12, 60);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(164, 23);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 500;
            this.trackBar1.Location = new System.Drawing.Point(12, 92);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 20000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(164, 45);
            this.trackBar1.SmallChange = 250;
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickFrequency = 250;
            this.trackBar1.Value = 5000;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "0-| Image Sending Delay (Secs) |-20";
            // 
            // mouseAndKeyboard
            // 
            this.mouseAndKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mouseAndKeyboard.Location = new System.Drawing.Point(12, 160);
            this.mouseAndKeyboard.Name = "mouseAndKeyboard";
            this.mouseAndKeyboard.Size = new System.Drawing.Size(168, 23);
            this.mouseAndKeyboard.TabIndex = 10;
            this.mouseAndKeyboard.TabStop = false;
            this.mouseAndKeyboard.Text = "Takeover Mouse and Keyboard";
            this.mouseAndKeyboard.UseVisualStyleBackColor = true;
            this.mouseAndKeyboard.Click += new System.EventHandler(this.mouseAndKeyboard_Click);
            // 
            // imageDelayLabel
            // 
            this.imageDelayLabel.Location = new System.Drawing.Point(23, 121);
            this.imageDelayLabel.Name = "imageDelayLabel";
            this.imageDelayLabel.Size = new System.Drawing.Size(142, 14);
            this.imageDelayLabel.TabIndex = 11;
            this.imageDelayLabel.Text = "5";
            this.imageDelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 12;
            this.button1.TabStop = false;
            this.button1.Text = "! Shutdown Server !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // funButton
            // 
            this.funButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.funButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funButton.Location = new System.Drawing.Point(12, 218);
            this.funButton.Name = "funButton";
            this.funButton.Size = new System.Drawing.Size(168, 23);
            this.funButton.TabIndex = 13;
            this.funButton.TabStop = false;
            this.funButton.Text = "(= -.^ .-*~ Fun Stuff ~*-.  ^.- =)";
            this.funButton.UseVisualStyleBackColor = true;
            this.funButton.Click += new System.EventHandler(this.funButton_Click);
            // 
            // blackScreen
            // 
            this.blackScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blackScreen.Location = new System.Drawing.Point(307, 6);
            this.blackScreen.Name = "blackScreen";
            this.blackScreen.Size = new System.Drawing.Size(83, 23);
            this.blackScreen.TabIndex = 14;
            this.blackScreen.TabStop = false;
            this.blackScreen.Text = "Black Screen";
            this.blackScreen.UseVisualStyleBackColor = true;
            this.blackScreen.Click += new System.EventHandler(this.blackScreen_Click);
            // 
            // matrixInput
            // 
            this.matrixInput.BackColor = System.Drawing.Color.Black;
            this.matrixInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matrixInput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matrixInput.ForeColor = System.Drawing.Color.Lime;
            this.matrixInput.Location = new System.Drawing.Point(209, 37);
            this.matrixInput.Name = "matrixInput";
            this.matrixInput.Size = new System.Drawing.Size(180, 18);
            this.matrixInput.TabIndex = 15;
            this.matrixInput.TextChanged += new System.EventHandler(this.matrixInput_TextChanged);
            // 
            // blackScreenLabel
            // 
            this.blackScreenLabel.AutoSize = true;
            this.blackScreenLabel.Location = new System.Drawing.Point(206, 58);
            this.blackScreenLabel.Name = "blackScreenLabel";
            this.blackScreenLabel.Size = new System.Drawing.Size(122, 13);
            this.blackScreenLabel.TabIndex = 16;
            this.blackScreenLabel.Text = "Type onto Black Screen";
            // 
            // beep
            // 
            this.beep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.beep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beep.Location = new System.Drawing.Point(209, 6);
            this.beep.Name = "beep";
            this.beep.Size = new System.Drawing.Size(83, 23);
            this.beep.TabIndex = 17;
            this.beep.TabStop = false;
            this.beep.Text = "Beep";
            this.beep.UseVisualStyleBackColor = true;
            this.beep.Click += new System.EventHandler(this.beep_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(401, 253);
            this.Controls.Add(this.beep);
            this.Controls.Add(this.blackScreenLabel);
            this.Controls.Add(this.matrixInput);
            this.Controls.Add(this.blackScreen);
            this.Controls.Add(this.funButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageDelayLabel);
            this.Controls.Add(this.mouseAndKeyboard);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ipAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.OrangeRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Controller";
            this.Text = "SKR v0.1-RC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button mouseAndKeyboard;
        private System.Windows.Forms.Label imageDelayLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button funButton;
        private System.Windows.Forms.Button blackScreen;
        private System.Windows.Forms.TextBox matrixInput;
        private System.Windows.Forms.Label blackScreenLabel;
        private System.Windows.Forms.Button beep;
    }
}

