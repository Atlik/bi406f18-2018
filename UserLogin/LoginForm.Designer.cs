namespace Login
{
    partial class LoginForm
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.nametxtbox = new System.Windows.Forms.TextBox();
            this.pwdtxtbox = new System.Windows.Forms.TextBox();
            this.Forgot_password = new System.Windows.Forms.LinkLabel();
            this.LoginPage = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.LoginDescription = new System.Windows.Forms.Label();
            this.RegisterDescription = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.Location = new System.Drawing.Point(185, 241);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(223, 29);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // nametxtbox
            // 
            this.nametxtbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nametxtbox.Location = new System.Drawing.Point(96, 148);
            this.nametxtbox.MaximumSize = new System.Drawing.Size(500, 20);
            this.nametxtbox.MinimumSize = new System.Drawing.Size(100, 20);
            this.nametxtbox.Name = "nametxtbox";
            this.nametxtbox.Size = new System.Drawing.Size(400, 20);
            this.nametxtbox.TabIndex = 3;
            // 
            // pwdtxtbox
            // 
            this.pwdtxtbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pwdtxtbox.Location = new System.Drawing.Point(96, 206);
            this.pwdtxtbox.MaximumSize = new System.Drawing.Size(500, 20);
            this.pwdtxtbox.MinimumSize = new System.Drawing.Size(100, 20);
            this.pwdtxtbox.Name = "pwdtxtbox";
            this.pwdtxtbox.PasswordChar = '*';
            this.pwdtxtbox.Size = new System.Drawing.Size(400, 20);
            this.pwdtxtbox.TabIndex = 4;
            // 
            // Forgot_password
            // 
            this.Forgot_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Forgot_password.AutoSize = true;
            this.Forgot_password.Location = new System.Drawing.Point(248, 284);
            this.Forgot_password.Name = "Forgot_password";
            this.Forgot_password.Size = new System.Drawing.Size(92, 13);
            this.Forgot_password.TabIndex = 5;
            this.Forgot_password.TabStop = true;
            this.Forgot_password.Text = "Forgot Password?";
            // 
            // LoginPage
            // 
            this.LoginPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginPage.AutoSize = true;
            this.LoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginPage.Location = new System.Drawing.Point(217, 35);
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.Size = new System.Drawing.Size(150, 31);
            this.LoginPage.TabIndex = 7;
            this.LoginPage.Text = "Login Page";
            this.LoginPage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Username
            // 
            this.Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(92, 125);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(87, 20);
            this.Username.TabIndex = 8;
            this.Username.Text = "Username:";
            // 
            // Password
            // 
            this.Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(92, 183);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(82, 20);
            this.Password.TabIndex = 9;
            this.Password.Text = "Password:";
            // 
            // LoginDescription
            // 
            this.LoginDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginDescription.AutoSize = true;
            this.LoginDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginDescription.Location = new System.Drawing.Point(153, 90);
            this.LoginDescription.Name = "LoginDescription";
            this.LoginDescription.Size = new System.Drawing.Size(284, 13);
            this.LoginDescription.TabIndex = 10;
            this.LoginDescription.Text = "Use your Username and Password to log into your account";
            // 
            // RegisterDescription
            // 
            this.RegisterDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterDescription.AutoSize = true;
            this.RegisterDescription.Enabled = false;
            this.RegisterDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterDescription.Location = new System.Drawing.Point(182, 357);
            this.RegisterDescription.Name = "RegisterDescription";
            this.RegisterDescription.Size = new System.Drawing.Size(229, 13);
            this.RegisterDescription.TabIndex = 11;
            this.RegisterDescription.Text = "If you don\'t have an account please click here:";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.Location = new System.Drawing.Point(185, 373);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(223, 29);
            this.RegisterButton.TabIndex = 12;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 460);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.RegisterDescription);
            this.Controls.Add(this.LoginDescription);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.LoginPage);
            this.Controls.Add(this.Forgot_password);
            this.Controls.Add(this.pwdtxtbox);
            this.Controls.Add(this.nametxtbox);
            this.Controls.Add(this.LoginButton);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diet Tracker v.0.1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox nametxtbox;
        private System.Windows.Forms.TextBox pwdtxtbox;
        private System.Windows.Forms.LinkLabel Forgot_password;
        private System.Windows.Forms.Label LoginPage;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label LoginDescription;
        private System.Windows.Forms.Label RegisterDescription;
        private System.Windows.Forms.Button RegisterButton;
    }
}

