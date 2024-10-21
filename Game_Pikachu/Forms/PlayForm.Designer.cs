namespace Game_Pikachu
{
    partial class PlayForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayForm));
            this.label4 = new System.Windows.Forms.Label();
            this.progressBarTime = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelContainIcon = new System.Windows.Forms.Panel();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptb_Thoat = new System.Windows.Forms.PictureBox();
            this.ptSend = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbTenUser = new System.Windows.Forms.Label();
            this.rbMessage = new System.Windows.Forms.RichTextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Thoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(198, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 40);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time";
            // 
            // progressBarTime
            // 
            this.progressBarTime.BackColor = System.Drawing.Color.DodgerBlue;
            this.progressBarTime.ForeColor = System.Drawing.Color.Gold;
            this.progressBarTime.Location = new System.Drawing.Point(315, 15);
            this.progressBarTime.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarTime.Maximum = 3000;
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(706, 32);
            this.progressBarTime.Step = 1;
            this.progressBarTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTime.TabIndex = 11;
            this.progressBarTime.Value = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelContainIcon
            // 
            this.panelContainIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainIcon.BackColor = System.Drawing.Color.Transparent;
            this.panelContainIcon.Location = new System.Drawing.Point(170, 63);
            this.panelContainIcon.Margin = new System.Windows.Forms.Padding(4);
            this.panelContainIcon.Name = "panelContainIcon";
            this.panelContainIcon.Size = new System.Drawing.Size(854, 505);
            this.panelContainIcon.TabIndex = 0;
            this.panelContainIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainIcon_Paint);
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(1040, 529);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(255, 42);
            this.txtChat.TabIndex = 16;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1283, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 57);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // ptb_Thoat
            // 
            this.ptb_Thoat.BackColor = System.Drawing.Color.Transparent;
            this.ptb_Thoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptb_Thoat.BackgroundImage")));
            this.ptb_Thoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptb_Thoat.Location = new System.Drawing.Point(12, 530);
            this.ptb_Thoat.Margin = new System.Windows.Forms.Padding(4);
            this.ptb_Thoat.Name = "ptb_Thoat";
            this.ptb_Thoat.Size = new System.Drawing.Size(146, 41);
            this.ptb_Thoat.TabIndex = 20;
            this.ptb_Thoat.TabStop = false;
            this.ptb_Thoat.Click += new System.EventHandler(this.ptb_Thoat_Click);
            // 
            // ptSend
            // 
            this.ptSend.BackColor = System.Drawing.Color.Transparent;
            this.ptSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptSend.BackgroundImage")));
            this.ptSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptSend.Location = new System.Drawing.Point(1302, 529);
            this.ptSend.Margin = new System.Windows.Forms.Padding(4);
            this.ptSend.Name = "ptSend";
            this.ptSend.Size = new System.Drawing.Size(41, 42);
            this.ptSend.TabIndex = 18;
            this.ptSend.TabStop = false;
            this.ptSend.Click += new System.EventHandler(this.ptSend_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Game_Pikachu.Properties.Resources.mute;
            this.pictureBox1.Location = new System.Drawing.Point(12, 70);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbTenUser
            // 
            this.lbTenUser.AutoSize = true;
            this.lbTenUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenUser.Location = new System.Drawing.Point(1157, 15);
            this.lbTenUser.Name = "lbTenUser";
            this.lbTenUser.Size = new System.Drawing.Size(86, 22);
            this.lbTenUser.TabIndex = 22;
            this.lbTenUser.Text = "TenUser";
            this.lbTenUser.Click += new System.EventHandler(this.lbTenUser_Click);
            // 
            // rbMessage
            // 
            this.rbMessage.Location = new System.Drawing.Point(1040, 70);
            this.rbMessage.Name = "rbMessage";
            this.rbMessage.Size = new System.Drawing.Size(303, 447);
            this.rbMessage.TabIndex = 25;
            this.rbMessage.Text = "";
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.SlateGray;
            this.txtIP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(12, 15);
            this.txtIP.Multiline = true;
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(160, 35);
            this.txtIP.TabIndex = 26;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(12, 474);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(146, 43);
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1377, 679);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.rbMessage);
            this.Controls.Add(this.lbTenUser);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ptb_Thoat);
            this.Controls.Add(this.ptSend);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBarTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelContainIcon);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayForm";
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.Shown += new System.EventHandler(this.PlayForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Thoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainIcon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBarTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.PictureBox ptSend;
        private System.Windows.Forms.PictureBox ptb_Thoat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbTenUser;
        private System.Windows.Forms.RichTextBox rbMessage;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}