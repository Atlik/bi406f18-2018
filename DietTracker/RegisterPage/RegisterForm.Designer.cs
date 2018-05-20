namespace Register
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
            this.RegisterPageActivityButton = new System.Windows.Forms.Button();
            this.RegisterPageRadioButtonMale = new System.Windows.Forms.RadioButton();
            this.RegisterPageRadioButtonFemale = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.RegisterPageActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterButton.Location = new System.Drawing.Point(181, 505);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(297, 36);
            this.RegisterButton.TabIndex = 11;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterPageLabel
            // 
            this.RegisterPageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageLabel.AutoSize = true;
            this.RegisterPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageLabel.Location = new System.Drawing.Point(213, 22);
            this.RegisterPageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterPageLabel.Name = "RegisterPageLabel";
            this.RegisterPageLabel.Size = new System.Drawing.Size(194, 39);
            this.RegisterPageLabel.TabIndex = 1;
            this.RegisterPageLabel.Text = "Your Profile";
            // 
            // RegisterPageWeight
            // 
            this.RegisterPageWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageWeight.Location = new System.Drawing.Point(265, 391);
            this.RegisterPageWeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageWeight.Name = "RegisterPageWeight";
            this.RegisterPageWeight.Size = new System.Drawing.Size(265, 28);
            this.RegisterPageWeight.TabIndex = 8;
            this.RegisterPageWeight.Tag = "kg";
            this.RegisterPageWeight.Text = "in kg";
            this.RegisterPageWeight.Enter += new System.EventHandler(this.RegisterTextWeight_Remove);
            // 
            // RegisterPageUsername
            // 
            this.RegisterPageUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageUsername.Location = new System.Drawing.Point(265, 108);
            this.RegisterPageUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageUsername.Name = "RegisterPageUsername";
            this.RegisterPageUsername.Size = new System.Drawing.Size(265, 28);
            this.RegisterPageUsername.TabIndex = 1;
            // 
            // RegisterPagePassword
            // 
            this.RegisterPagePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPagePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPagePassword.Location = new System.Drawing.Point(264, 162);
            this.RegisterPagePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPagePassword.Name = "RegisterPagePassword";
            this.RegisterPagePassword.PasswordChar = '*';
            this.RegisterPagePassword.Size = new System.Drawing.Size(265, 28);
            this.RegisterPagePassword.TabIndex = 2;
            this.RegisterPagePassword.UseSystemPasswordChar = true;
            // 
            // RegisterPageDoB
            // 
            this.RegisterPageDoB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageDoB.CustomFormat = "";
            this.RegisterPageDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageDoB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RegisterPageDoB.Location = new System.Drawing.Point(265, 299);
            this.RegisterPageDoB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageDoB.Name = "RegisterPageDoB";
            this.RegisterPageDoB.Size = new System.Drawing.Size(265, 28);
            this.RegisterPageDoB.TabIndex = 6;
            this.RegisterPageDoB.Value = new System.DateTime(2018, 5, 10, 0, 0, 0, 0);
            this.RegisterPageDoB.ValueChanged += new System.EventHandler(this.RegisterPageDoB_ValueChanged);
            // 
            // RegisterLabelUsername
            // 
            this.RegisterLabelUsername.AutoSize = true;
            this.RegisterLabelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelUsername.Location = new System.Drawing.Point(61, 112);
            this.RegisterLabelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabelUsername.Name = "RegisterLabelUsername";
            this.RegisterLabelUsername.Size = new System.Drawing.Size(186, 24);
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
            this.LoginPageBack.Location = new System.Drawing.Point(16, 22);
            this.LoginPageBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginPageBack.Name = "LoginPageBack";
            this.LoginPageBack.Size = new System.Drawing.Size(60, 28);
            this.LoginPageBack.TabIndex = 12;
            this.LoginPageBack.Text = "Home";
            this.LoginPageBack.UseVisualStyleBackColor = false;
            this.LoginPageBack.Click += new System.EventHandler(this.Home_Click);
            // 
            // RegisterLabelName
            // 
            this.RegisterLabelName.AutoSize = true;
            this.RegisterLabelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelName.Location = new System.Drawing.Point(105, 236);
            this.RegisterLabelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabelName.Name = "RegisterLabelName";
            this.RegisterLabelName.Size = new System.Drawing.Size(143, 24);
            this.RegisterLabelName.TabIndex = 18;
            this.RegisterLabelName.Text = "Your Firstname:";
            // 
            // RegisterPageHeight
            // 
            this.RegisterPageHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageHeight.Location = new System.Drawing.Point(265, 346);
            this.RegisterPageHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageHeight.Name = "RegisterPageHeight";
            this.RegisterPageHeight.Size = new System.Drawing.Size(265, 28);
            this.RegisterPageHeight.TabIndex = 7;
            this.RegisterPageHeight.Tag = "cm";
            this.RegisterPageHeight.Text = "in cm";
            this.RegisterPageHeight.TextChanged += new System.EventHandler(this.RegisterPageHeight_TextChanged);
            this.RegisterPageHeight.Enter += new System.EventHandler(this.RegisterTextHeight_Remove);
            this.RegisterPageHeight.Leave += new System.EventHandler(this.RegisterTextHeight_Add);
            // 
            // RegisterPageName
            // 
            this.RegisterPageName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageName.Location = new System.Drawing.Point(265, 233);
            this.RegisterPageName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageName.Name = "RegisterPageName";
            this.RegisterPageName.Size = new System.Drawing.Size(265, 28);
            this.RegisterPageName.TabIndex = 3;
            // 
            // RegisterLabelPassword
            // 
            this.RegisterLabelPassword.AutoSize = true;
            this.RegisterLabelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelPassword.Location = new System.Drawing.Point(61, 166);
            this.RegisterLabelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabelPassword.Name = "RegisterLabelPassword";
            this.RegisterLabelPassword.Size = new System.Drawing.Size(182, 24);
            this.RegisterLabelPassword.TabIndex = 21;
            this.RegisterLabelPassword.Text = "Choose a password:";
            // 
            // RegsterLabelDoB
            // 
            this.RegsterLabelDoB.AutoSize = true;
            this.RegsterLabelDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegsterLabelDoB.Location = new System.Drawing.Point(84, 305);
            this.RegsterLabelDoB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegsterLabelDoB.Name = "RegsterLabelDoB";
            this.RegsterLabelDoB.Size = new System.Drawing.Size(160, 24);
            this.RegsterLabelDoB.TabIndex = 22;
            this.RegsterLabelDoB.Text = "Your Date of Birth:";
            // 
            // RegisterLabelHeight
            // 
            this.RegisterLabelHeight.AutoSize = true;
            this.RegisterLabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelHeight.Location = new System.Drawing.Point(137, 350);
            this.RegisterLabelHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabelHeight.Name = "RegisterLabelHeight";
            this.RegisterLabelHeight.Size = new System.Drawing.Size(115, 24);
            this.RegisterLabelHeight.TabIndex = 23;
            this.RegisterLabelHeight.Text = "Your Height:";
            // 
            // RegisterLabelWeight
            // 
            this.RegisterLabelWeight.AutoSize = true;
            this.RegisterLabelWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabelWeight.Location = new System.Drawing.Point(132, 395);
            this.RegisterLabelWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabelWeight.Name = "RegisterLabelWeight";
            this.RegisterLabelWeight.Size = new System.Drawing.Size(119, 24);
            this.RegisterLabelWeight.TabIndex = 24;
            this.RegisterLabelWeight.Text = "Your Weight:";
            // 
            // RegisterPageActivity
            // 
            this.RegisterPageActivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageActivity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterPageActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterPageActivity.Location = new System.Drawing.Point(265, 441);
            this.RegisterPageActivity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.RegisterPageActivity.Size = new System.Drawing.Size(59, 28);
            this.RegisterPageActivity.TabIndex = 9;
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
            this.RegisterLabelActivity.Location = new System.Drawing.Point(85, 443);
            this.RegisterLabelActivity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabelActivity.Name = "RegisterLabelActivity";
            this.RegisterLabelActivity.Size = new System.Drawing.Size(162, 24);
            this.RegisterLabelActivity.TabIndex = 26;
            this.RegisterLabelActivity.Text = "Your Daily Activity:";
            // 
            // RegisterPageActivityButton
            // 
            this.RegisterPageActivityButton.Location = new System.Drawing.Point(332, 441);
            this.RegisterPageActivityButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageActivityButton.Name = "RegisterPageActivityButton";
            this.RegisterPageActivityButton.Size = new System.Drawing.Size(125, 28);
            this.RegisterPageActivityButton.TabIndex = 10;
            this.RegisterPageActivityButton.Text = "What is activity?";
            this.RegisterPageActivityButton.UseVisualStyleBackColor = true;
            this.RegisterPageActivityButton.Click += new System.EventHandler(this.RegisterPageActivityButton_Click);
            // 
            // RegisterPageRadioButtonMale
            // 
            this.RegisterPageRadioButtonMale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageRadioButtonMale.AutoSize = true;
            this.RegisterPageRadioButtonMale.Location = new System.Drawing.Point(265, 270);
            this.RegisterPageRadioButtonMale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageRadioButtonMale.Name = "RegisterPageRadioButtonMale";
            this.RegisterPageRadioButtonMale.Size = new System.Drawing.Size(59, 21);
            this.RegisterPageRadioButtonMale.TabIndex = 4;
            this.RegisterPageRadioButtonMale.TabStop = true;
            this.RegisterPageRadioButtonMale.Text = "Male";
            this.RegisterPageRadioButtonMale.UseVisualStyleBackColor = true;
            // 
            // RegisterPageRadioButtonFemale
            // 
            this.RegisterPageRadioButtonFemale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterPageRadioButtonFemale.AutoSize = true;
            this.RegisterPageRadioButtonFemale.Location = new System.Drawing.Point(341, 270);
            this.RegisterPageRadioButtonFemale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterPageRadioButtonFemale.Name = "RegisterPageRadioButtonFemale";
            this.RegisterPageRadioButtonFemale.Size = new System.Drawing.Size(75, 21);
            this.RegisterPageRadioButtonFemale.TabIndex = 5;
            this.RegisterPageRadioButtonFemale.TabStop = true;
            this.RegisterPageRadioButtonFemale.Text = "Female";
            this.RegisterPageRadioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.RegisterButton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(645, 567);
            this.Controls.Add(this.RegisterPageRadioButtonFemale);
            this.Controls.Add(this.RegisterPageRadioButtonMale);
            this.Controls.Add(this.RegisterPageActivityButton);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(661, 605);
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
        private System.Windows.Forms.Button RegisterPageActivityButton;
        private System.Windows.Forms.RadioButton RegisterPageRadioButtonMale;
        private System.Windows.Forms.RadioButton RegisterPageRadioButtonFemale;
    }
}