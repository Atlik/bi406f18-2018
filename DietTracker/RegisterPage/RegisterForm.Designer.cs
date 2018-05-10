﻿namespace Register
{
    partial class RegisterForm
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
            this.RegisterButton = new System.Windows.Forms.Button();
            this.RegisterPageLabel = new System.Windows.Forms.Label();
            this.RegisterPageWeight = new System.Windows.Forms.TextBox();
            this.RegisterPageUsername = new System.Windows.Forms.TextBox();
            this.RegisterPagePassword = new System.Windows.Forms.TextBox();
            this.RegisterPageDoB = new System.Windows.Forms.DateTimePicker();
            this.RegisterLabelUsername = new System.Windows.Forms.Label();
            this.LoginPageBack = new System.Windows.Forms.Button();
            this.RegisterLabelName = new System.Windows.Forms.Label();
            this.RegisterPageHeight = new System.Windows.Forms.TextBox();
            this.RegisterPageName = new System.Windows.Forms.TextBox();
            this.RegisterLabelPassword = new System.Windows.Forms.Label();
            this.RegsterLabelDoB = new System.Windows.Forms.Label();
            this.RegisterLabelHeight = new System.Windows.Forms.Label();
            this.RegisterLabelWeight = new System.Windows.Forms.Label();
            this.RegisterPageActivity = new System.Windows.Forms.NumericUpDown();
            this.RegisterLabelActivity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RegisterPageActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterButton.Location = new System.Drawing.Point(136, 410);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(223, 29);
            this.RegisterButton.TabIndex = 8;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterPageLabel
            // 
            this.RegisterPageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageLabel.AutoSize = true;
            this.RegisterPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageLabel.Location = new System.Drawing.Point(160, 18);
            this.RegisterPageLabel.Name = "RegisterPageLabel";
            this.RegisterPageLabel.Size = new System.Drawing.Size(155, 31);
            this.RegisterPageLabel.TabIndex = 1;
            this.RegisterPageLabel.Text = "Your Profile";
            // 
            // RegisterPageWeight
            // 
            this.RegisterPageWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageWeight.Location = new System.Drawing.Point(199, 318);
            this.RegisterPageWeight.Name = "RegisterPageWeight";
            this.RegisterPageWeight.Size = new System.Drawing.Size(200, 24);
            this.RegisterPageWeight.TabIndex = 6;
            this.RegisterPageWeight.Tag = "kg";
            // 
            // RegisterPageUsername
            // 
            this.RegisterPageUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageUsername.Location = new System.Drawing.Point(199, 88);
            this.RegisterPageUsername.Name = "RegisterPageUsername";
            this.RegisterPageUsername.Size = new System.Drawing.Size(200, 24);
            this.RegisterPageUsername.TabIndex = 1;
            // 
            // RegisterPagePassword
            // 
            this.RegisterPagePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPagePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPagePassword.Location = new System.Drawing.Point(198, 132);
            this.RegisterPagePassword.Name = "RegisterPagePassword";
            this.RegisterPagePassword.PasswordChar = '*';
            this.RegisterPagePassword.Size = new System.Drawing.Size(200, 24);
            this.RegisterPagePassword.TabIndex = 2;
            this.RegisterPagePassword.UseSystemPasswordChar = true;
            // 
            // RegisterPageDoB
            // 
            this.RegisterPageDoB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageDoB.CustomFormat = "";
            this.RegisterPageDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageDoB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RegisterPageDoB.Location = new System.Drawing.Point(199, 243);
            this.RegisterPageDoB.Name = "RegisterPageDoB";
            this.RegisterPageDoB.Size = new System.Drawing.Size(200, 24);
            this.RegisterPageDoB.TabIndex = 4;
            this.RegisterPageDoB.Value = new System.DateTime(2018, 5, 10, 0, 0, 0, 0);
            // 
            // RegisterLabelUsername
            // 
            this.RegisterLabelUsername.AutoSize = true;
            this.RegisterLabelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelUsername.Location = new System.Drawing.Point(46, 91);
            this.RegisterLabelUsername.Name = "RegisterLabelUsername";
            this.RegisterLabelUsername.Size = new System.Drawing.Size(147, 18);
            this.RegisterLabelUsername.TabIndex = 8;
            this.RegisterLabelUsername.Text = "Choose a username:";
            // 
            // LoginPageBack
            // 
            this.LoginPageBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginPageBack.AutoSize = true;
            this.LoginPageBack.BackColor = System.Drawing.Color.Transparent;
            this.LoginPageBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoginPageBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginPageBack.FlatAppearance.BorderSize = 0;
            this.LoginPageBack.ForeColor = System.Drawing.Color.Transparent;
            this.LoginPageBack.Location = new System.Drawing.Point(12, 18);
            this.LoginPageBack.Name = "LoginPageBack";
            this.LoginPageBack.Size = new System.Drawing.Size(45, 23);
            this.LoginPageBack.TabIndex = 14;
            this.LoginPageBack.Text = "Home";
            this.LoginPageBack.UseVisualStyleBackColor = false;
            this.LoginPageBack.Click += new System.EventHandler(this.Home_Click);
            // 
            // RegisterLabelName
            // 
            this.RegisterLabelName.AutoSize = true;
            this.RegisterLabelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelName.Location = new System.Drawing.Point(108, 207);
            this.RegisterLabelName.Name = "RegisterLabelName";
            this.RegisterLabelName.Size = new System.Drawing.Size(84, 18);
            this.RegisterLabelName.TabIndex = 18;
            this.RegisterLabelName.Text = "Your name:";
            // 
            // RegisterPageHeight
            // 
            this.RegisterPageHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageHeight.Location = new System.Drawing.Point(199, 281);
            this.RegisterPageHeight.Name = "RegisterPageHeight";
            this.RegisterPageHeight.Size = new System.Drawing.Size(200, 24);
            this.RegisterPageHeight.TabIndex = 5;
            this.RegisterPageHeight.Tag = "cm";
            // 
            // RegisterPageName
            // 
            this.RegisterPageName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageName.Location = new System.Drawing.Point(199, 204);
            this.RegisterPageName.Name = "RegisterPageName";
            this.RegisterPageName.Size = new System.Drawing.Size(200, 24);
            this.RegisterPageName.TabIndex = 3;
            // 
            // RegisterLabelPassword
            // 
            this.RegisterLabelPassword.AutoSize = true;
            this.RegisterLabelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelPassword.Location = new System.Drawing.Point(46, 135);
            this.RegisterLabelPassword.Name = "RegisterLabelPassword";
            this.RegisterLabelPassword.Size = new System.Drawing.Size(146, 18);
            this.RegisterLabelPassword.TabIndex = 21;
            this.RegisterLabelPassword.Text = "Choose a password:";
            // 
            // RegsterLabelDoB
            // 
            this.RegsterLabelDoB.AutoSize = true;
            this.RegsterLabelDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegsterLabelDoB.Location = new System.Drawing.Point(63, 248);
            this.RegsterLabelDoB.Name = "RegsterLabelDoB";
            this.RegsterLabelDoB.Size = new System.Drawing.Size(129, 18);
            this.RegsterLabelDoB.TabIndex = 22;
            this.RegsterLabelDoB.Text = "Your Date of Birth:";
            // 
            // RegisterLabelHeight
            // 
            this.RegisterLabelHeight.AutoSize = true;
            this.RegisterLabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelHeight.Location = new System.Drawing.Point(103, 284);
            this.RegisterLabelHeight.Name = "RegisterLabelHeight";
            this.RegisterLabelHeight.Size = new System.Drawing.Size(89, 18);
            this.RegisterLabelHeight.TabIndex = 23;
            this.RegisterLabelHeight.Text = "Your Height:";
            // 
            // RegisterLabelWeight
            // 
            this.RegisterLabelWeight.AutoSize = true;
            this.RegisterLabelWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelWeight.Location = new System.Drawing.Point(99, 321);
            this.RegisterLabelWeight.Name = "RegisterLabelWeight";
            this.RegisterLabelWeight.Size = new System.Drawing.Size(93, 18);
            this.RegisterLabelWeight.TabIndex = 24;
            this.RegisterLabelWeight.Text = "Your Weight:";
            // 
            // RegisterPageActivity
            // 
            this.RegisterPageActivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageActivity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterPageActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageActivity.Location = new System.Drawing.Point(199, 358);
            this.RegisterPageActivity.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RegisterPageActivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RegisterPageActivity.Name = "RegisterPageActivity";
            this.RegisterPageActivity.Size = new System.Drawing.Size(44, 24);
            this.RegisterPageActivity.TabIndex = 7;
            this.RegisterPageActivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RegisterPageActivity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RegisterLabelActivity
            // 
            this.RegisterLabelActivity.AutoSize = true;
            this.RegisterLabelActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelActivity.Location = new System.Drawing.Point(64, 360);
            this.RegisterLabelActivity.Name = "RegisterLabelActivity";
            this.RegisterLabelActivity.Size = new System.Drawing.Size(128, 18);
            this.RegisterLabelActivity.TabIndex = 26;
            this.RegisterLabelActivity.Text = "Your Daily Activity:";
            // 
            // RegisterForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.RegisterLabelActivity);
            this.Controls.Add(this.RegisterPageActivity);
            this.Controls.Add(this.RegisterLabelWeight);
            this.Controls.Add(this.RegisterLabelHeight);
            this.Controls.Add(this.RegsterLabelDoB);
            this.Controls.Add(this.RegisterLabelPassword);
            this.Controls.Add(this.RegisterPageName);
            this.Controls.Add(this.RegisterPageHeight);
            this.Controls.Add(this.RegisterLabelName);
            this.Controls.Add(this.LoginPageBack);
            this.Controls.Add(this.RegisterLabelUsername);
            this.Controls.Add(this.RegisterPageDoB);
            this.Controls.Add(this.RegisterPagePassword);
            this.Controls.Add(this.RegisterPageUsername);
            this.Controls.Add(this.RegisterPageWeight);
            this.Controls.Add(this.RegisterPageLabel);
            this.Controls.Add(this.RegisterButton);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diet Tracker v.0.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterPage_Closed);
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RegisterPageActivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label RegisterPageLabel;
        private System.Windows.Forms.TextBox RegisterPageWeight;
        private System.Windows.Forms.TextBox RegisterPageUsername;
        private System.Windows.Forms.TextBox RegisterPagePassword;
        private System.Windows.Forms.DateTimePicker RegisterPageDoB;
        private System.Windows.Forms.Label RegisterLabelUsername;
        private System.Windows.Forms.Button LoginPageBack;
        private System.Windows.Forms.Label RegisterLabelName;
        private System.Windows.Forms.TextBox RegisterPageHeight;
        private System.Windows.Forms.TextBox RegisterPageName;
        private System.Windows.Forms.Label RegisterLabelPassword;
        private System.Windows.Forms.Label RegsterLabelDoB;
        private System.Windows.Forms.Label RegisterLabelHeight;
        private System.Windows.Forms.Label RegisterLabelWeight;
        private System.Windows.Forms.NumericUpDown RegisterPageActivity;
        private System.Windows.Forms.Label RegisterLabelActivity;
    }
}