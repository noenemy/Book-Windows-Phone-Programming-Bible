namespace PushClient
{
    partial class Form1
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
            this.txtURI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUnregister = new System.Windows.Forms.Button();
            this.txtToastTitle = new System.Windows.Forms.TextBox();
            this.txtToastSubtitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendToastNotification = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtTileTitle = new System.Windows.Forms.TextBox();
            this.btnSendTileNotification = new System.Windows.Forms.Button();
            this.comBackground = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRawMessage = new System.Windows.Forms.TextBox();
            this.btnSendRawNotification = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtURI
            // 
            this.txtURI.Location = new System.Drawing.Point(15, 32);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(396, 21);
            this.txtURI.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel URI :";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(255, 59);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnUnregister
            // 
            this.btnUnregister.Location = new System.Drawing.Point(336, 59);
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.Size = new System.Drawing.Size(75, 23);
            this.btnUnregister.TabIndex = 3;
            this.btnUnregister.Text = "Unregister";
            this.btnUnregister.UseVisualStyleBackColor = true;
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);
            // 
            // txtToastTitle
            // 
            this.txtToastTitle.Location = new System.Drawing.Point(77, 97);
            this.txtToastTitle.Name = "txtToastTitle";
            this.txtToastTitle.Size = new System.Drawing.Size(334, 21);
            this.txtToastTitle.TabIndex = 4;
            // 
            // txtToastSubtitle
            // 
            this.txtToastSubtitle.Location = new System.Drawing.Point(77, 124);
            this.txtToastSubtitle.Name = "txtToastSubtitle";
            this.txtToastSubtitle.Size = new System.Drawing.Size(334, 21);
            this.txtToastSubtitle.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Title :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subtitle :";
            // 
            // btnSendToastNotification
            // 
            this.btnSendToastNotification.Location = new System.Drawing.Point(255, 152);
            this.btnSendToastNotification.Name = "btnSendToastNotification";
            this.btnSendToastNotification.Size = new System.Drawing.Size(156, 23);
            this.btnSendToastNotification.TabIndex = 6;
            this.btnSendToastNotification.Text = "Send Toast Notification";
            this.btnSendToastNotification.UseVisualStyleBackColor = true;
            this.btnSendToastNotification.Click += new System.EventHandler(this.btnSendToastNotification_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(77, 193);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(121, 21);
            this.txtCount.TabIndex = 7;
            // 
            // txtTileTitle
            // 
            this.txtTileTitle.Location = new System.Drawing.Point(77, 220);
            this.txtTileTitle.Name = "txtTileTitle";
            this.txtTileTitle.Size = new System.Drawing.Size(334, 21);
            this.txtTileTitle.TabIndex = 9;
            // 
            // btnSendTileNotification
            // 
            this.btnSendTileNotification.Location = new System.Drawing.Point(255, 247);
            this.btnSendTileNotification.Name = "btnSendTileNotification";
            this.btnSendTileNotification.Size = new System.Drawing.Size(156, 23);
            this.btnSendTileNotification.TabIndex = 10;
            this.btnSendTileNotification.Text = "Send Tile Notification";
            this.btnSendTileNotification.UseVisualStyleBackColor = true;
            this.btnSendTileNotification.Click += new System.EventHandler(this.btnSendTileNotification_Click);
            // 
            // comBackground
            // 
            this.comBackground.FormattingEnabled = true;
            this.comBackground.Items.AddRange(new object[] {
            "images/facebook.png",
            "images/twitter.png",
            "images/default.png"});
            this.comBackground.Location = new System.Drawing.Point(290, 193);
            this.comBackground.Name = "comBackground";
            this.comBackground.Size = new System.Drawing.Size(121, 20);
            this.comBackground.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Count :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Title :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Background :";
            // 
            // txtRawMessage
            // 
            this.txtRawMessage.Location = new System.Drawing.Point(77, 290);
            this.txtRawMessage.Name = "txtRawMessage";
            this.txtRawMessage.Size = new System.Drawing.Size(334, 21);
            this.txtRawMessage.TabIndex = 11;
            // 
            // btnSendRawNotification
            // 
            this.btnSendRawNotification.Location = new System.Drawing.Point(255, 317);
            this.btnSendRawNotification.Name = "btnSendRawNotification";
            this.btnSendRawNotification.Size = new System.Drawing.Size(156, 23);
            this.btnSendRawNotification.TabIndex = 12;
            this.btnSendRawNotification.Text = "Send Raw Notification";
            this.btnSendRawNotification.UseVisualStyleBackColor = true;
            this.btnSendRawNotification.Click += new System.EventHandler(this.btnSendRawNotification_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "Message :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 362);
            this.Controls.Add(this.comBackground);
            this.Controls.Add(this.btnSendRawNotification);
            this.Controls.Add(this.btnSendTileNotification);
            this.Controls.Add(this.btnSendToastNotification);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRawMessage);
            this.Controls.Add(this.txtTileTitle);
            this.Controls.Add(this.txtToastSubtitle);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtToastTitle);
            this.Controls.Add(this.btnUnregister);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURI);
            this.Name = "Form1";
            this.Text = "Push Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUnregister;
        private System.Windows.Forms.TextBox txtToastTitle;
        private System.Windows.Forms.TextBox txtToastSubtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendToastNotification;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtTileTitle;
        private System.Windows.Forms.Button btnSendTileNotification;
        private System.Windows.Forms.ComboBox comBackground;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRawMessage;
        private System.Windows.Forms.Button btnSendRawNotification;
        private System.Windows.Forms.Label label7;
    }
}

