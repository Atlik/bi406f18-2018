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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.nametxtbox = new System.Windows.Forms.TextBox();
            this.pwdtxtbox = new System.Windows.Forms.TextBox();
            this.Forgot_password = new System.Windows.Forms.LinkLabel();
            this.Register = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(137, 109);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // nametxtbox
            // 
            this.nametxtbox.Location = new System.Drawing.Point(73, 21);
            this.nametxtbox.Name = "nametxtbox";
            this.nametxtbox.Size = new System.Drawing.Size(139, 20);
            this.nametxtbox.TabIndex = 3;
            // 
            // pwdtxtbox
            // 
            this.pwdtxtbox.Location = new System.Drawing.Point(73, 66);
            this.pwdtxtbox.Name = "pwdtxtbox";
            this.pwdtxtbox.Size = new System.Drawing.Size(139, 20);
            this.pwdtxtbox.TabIndex = 4;
            // 
            // Forgot_password
            // 
            this.Forgot_password.AutoSize = true;
            this.Forgot_password.Location = new System.Drawing.Point(120, 162);
            this.Forgot_password.Name = "Forgot_password";
            this.Forgot_password.Size = new System.Drawing.Size(92, 13);
            this.Forgot_password.TabIndex = 5;
            this.Forgot_password.TabStop = true;
            this.Forgot_password.Text = "Forgot Password?";
            // 
            // Register
            // 
            this.Register.AutoSize = true;
            this.Register.Location = new System.Drawing.Point(95, 200);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(117, 13);
            this.Register.TabIndex = 6;
            this.Register.TabStop = true;
            this.Register.Text = "Register new account?";
            // 
            // LoginForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(243, 252);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.Forgot_password);
            this.Controls.Add(this.pwdtxtbox);
            this.Controls.Add(this.nametxtbox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox nametxtbox;
        private System.Windows.Forms.TextBox pwdtxtbox;
        private System.Windows.Forms.LinkLabel Forgot_password;
        private System.Windows.Forms.LinkLabel Register;
    }
}

