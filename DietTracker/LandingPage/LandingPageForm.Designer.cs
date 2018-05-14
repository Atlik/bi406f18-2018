namespace LandingPage
{
    /// <summary>
    /// 
    /// </summary>
    partial class LandingPageForm
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
            this.LandingPageWelcome = new System.Windows.Forms.Label();
            this.LandingPageDescription1 = new System.Windows.Forms.Label();
            this.LandingPageRegister = new System.Windows.Forms.Button();
            this.LandingPageLogin = new System.Windows.Forms.Button();
            this.LandingPageDescription2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LandingPageWelcome
            // 
            this.LandingPageWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LandingPageWelcome.AutoSize = true;
            this.LandingPageWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandingPageWelcome.Location = new System.Drawing.Point(172, 39);
            this.LandingPageWelcome.Name = "LandingPageWelcome";
            this.LandingPageWelcome.Size = new System.Drawing.Size(126, 31);
            this.LandingPageWelcome.TabIndex = 0;
            this.LandingPageWelcome.Text = "Welcome";
            // 
            // LandingPageDescription1
            // 
            this.LandingPageDescription1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LandingPageDescription1.AutoSize = true;
            this.LandingPageDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandingPageDescription1.Location = new System.Drawing.Point(55, 97);
            this.LandingPageDescription1.MaximumSize = new System.Drawing.Size(400, 0);
            this.LandingPageDescription1.Name = "LandingPageDescription1";
            this.LandingPageDescription1.Size = new System.Drawing.Size(373, 65);
            this.LandingPageDescription1.TabIndex = 1;
            this.LandingPageDescription1.Text = "Welcome To our Health Application. We will try to help you keep track of your Wei" +
    "ght and Calories.\r\n\r\nHowever, before we can help you, we would need a bit of inf" +
    "ormation about yourself.";
            this.LandingPageDescription1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LandingPageRegister
            // 
            this.LandingPageRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LandingPageRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LandingPageRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandingPageRegister.Location = new System.Drawing.Point(131, 202);
            this.LandingPageRegister.Name = "LandingPageRegister";
            this.LandingPageRegister.Size = new System.Drawing.Size(223, 29);
            this.LandingPageRegister.TabIndex = 2;
            this.LandingPageRegister.Text = "Register";
            this.LandingPageRegister.UseVisualStyleBackColor = true;
            this.LandingPageRegister.Click += new System.EventHandler(this.LandingPageRegister_Click);
            // 
            // LandingPageLogin
            // 
            this.LandingPageLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LandingPageLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LandingPageLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandingPageLogin.Location = new System.Drawing.Point(131, 364);
            this.LandingPageLogin.Name = "LandingPageLogin";
            this.LandingPageLogin.Size = new System.Drawing.Size(223, 29);
            this.LandingPageLogin.TabIndex = 3;
            this.LandingPageLogin.Text = "Login";
            this.LandingPageLogin.UseVisualStyleBackColor = true;
            this.LandingPageLogin.Click += new System.EventHandler(this.LandingPageLogin_Click);
            // 
            // LandingPageDescription2
            // 
            this.LandingPageDescription2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LandingPageDescription2.AutoSize = true;
            this.LandingPageDescription2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LandingPageDescription2.Location = new System.Drawing.Point(74, 337);
            this.LandingPageDescription2.MaximumSize = new System.Drawing.Size(400, 0);
            this.LandingPageDescription2.Name = "LandingPageDescription2";
            this.LandingPageDescription2.Size = new System.Drawing.Size(336, 13);
            this.LandingPageDescription2.TabIndex = 4;
            this.LandingPageDescription2.Text = "If you already happen to have an account, you can always login here:";
            this.LandingPageDescription2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LandingPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.LandingPageDescription2);
            this.Controls.Add(this.LandingPageLogin);
            this.Controls.Add(this.LandingPageRegister);
            this.Controls.Add(this.LandingPageDescription1);
            this.Controls.Add(this.LandingPageWelcome);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "LandingPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diet Tracker v.0.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LandingPage_Closed);
            this.Load += new System.EventHandler(this.LandingPageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LandingPageWelcome;
        private System.Windows.Forms.Label LandingPageDescription1;
        private System.Windows.Forms.Button LandingPageRegister;
        private System.Windows.Forms.Button LandingPageLogin;
        private System.Windows.Forms.Label LandingPageDescription2;
    }
}

