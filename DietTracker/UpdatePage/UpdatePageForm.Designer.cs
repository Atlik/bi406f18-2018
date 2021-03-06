﻿namespace DietTracker.UpdatePage
{
    /// <summary>
    /// This is all the necessary design code for the updatepage form
    /// </summary>
    partial class UpdatePageForm
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
            this.UpdateButton = new System.Windows.Forms.Button();
            this.MainPageBack = new System.Windows.Forms.Button();
            this.UpdatePageLabel = new System.Windows.Forms.Label();
            this.UpdatePagePassword = new System.Windows.Forms.TextBox();
            this.UpdatePageName = new System.Windows.Forms.TextBox();
            this.UpdatePageWeight = new System.Windows.Forms.TextBox();
            this.UpdatePageHeight = new System.Windows.Forms.TextBox();
            this.UpdateLabelPassword = new System.Windows.Forms.Label();
            this.UpdateLabelName = new System.Windows.Forms.Label();
            this.UpdateLabelDoB = new System.Windows.Forms.Label();
            this.UpdateLabelHeight = new System.Windows.Forms.Label();
            this.UpdateLabelWeight = new System.Windows.Forms.Label();
            this.UpdateLabelActivity = new System.Windows.Forms.Label();
            this.UpdatePageDoB = new System.Windows.Forms.DateTimePicker();
            this.UpdatePageActivity = new System.Windows.Forms.NumericUpDown();
            this.UpdatePageActivityButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UpdatePageActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateButton.Location = new System.Drawing.Point(181, 505);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(297, 36);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // MainPageBack
            // 
            this.MainPageBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPageBack.AutoSize = true;
            this.MainPageBack.BackColor = System.Drawing.Color.Transparent;
            this.MainPageBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainPageBack.ForeColor = System.Drawing.Color.Transparent;
            this.MainPageBack.Location = new System.Drawing.Point(16, 22);
            this.MainPageBack.Margin = new System.Windows.Forms.Padding(4);
            this.MainPageBack.Name = "MainPageBack";
            this.MainPageBack.Size = new System.Drawing.Size(60, 28);
            this.MainPageBack.TabIndex = 12;
            this.MainPageBack.Text = "Home";
            this.MainPageBack.UseVisualStyleBackColor = false;
            this.MainPageBack.Click += new System.EventHandler(this.MainPageBack_Click);
            // 
            // UpdatePageLabel
            // 
            this.UpdatePageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePageLabel.AutoSize = true;
            this.UpdatePageLabel.BackColor = System.Drawing.Color.White;
            this.UpdatePageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePageLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdatePageLabel.Location = new System.Drawing.Point(159, 22);
            this.UpdatePageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdatePageLabel.Name = "UpdatePageLabel";
            this.UpdatePageLabel.Size = new System.Drawing.Size(313, 39);
            this.UpdatePageLabel.TabIndex = 1;
            this.UpdatePageLabel.Text = "Update Your Profile";
            // 
            // UpdatePagePassword
            // 
            this.UpdatePagePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePagePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePagePassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdatePagePassword.Location = new System.Drawing.Point(269, 166);
            this.UpdatePagePassword.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePagePassword.Name = "UpdatePagePassword";
            this.UpdatePagePassword.Size = new System.Drawing.Size(265, 28);
            this.UpdatePagePassword.TabIndex = 1;
            // 
            // UpdatePageName
            // 
            this.UpdatePageName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePageName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdatePageName.Location = new System.Drawing.Point(269, 236);
            this.UpdatePageName.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePageName.Name = "UpdatePageName";
            this.UpdatePageName.Size = new System.Drawing.Size(265, 28);
            this.UpdatePageName.TabIndex = 2;
            // 
            // UpdatePageWeight
            // 
            this.UpdatePageWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePageWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePageWeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdatePageWeight.Location = new System.Drawing.Point(269, 395);
            this.UpdatePageWeight.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePageWeight.Name = "UpdatePageWeight";
            this.UpdatePageWeight.Size = new System.Drawing.Size(265, 28);
            this.UpdatePageWeight.TabIndex = 5;
            this.UpdatePageWeight.Tag = "kg";
            // 
            // UpdatePageHeight
            // 
            this.UpdatePageHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePageHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePageHeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdatePageHeight.Location = new System.Drawing.Point(269, 350);
            this.UpdatePageHeight.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePageHeight.Name = "UpdatePageHeight";
            this.UpdatePageHeight.Size = new System.Drawing.Size(265, 28);
            this.UpdatePageHeight.TabIndex = 4;
            this.UpdatePageHeight.Tag = "cm";
            // 
            // UpdateLabelPassword
            // 
            this.UpdateLabelPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateLabelPassword.AutoSize = true;
            this.UpdateLabelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabelPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateLabelPassword.Location = new System.Drawing.Point(91, 166);
            this.UpdateLabelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateLabelPassword.Name = "UpdateLabelPassword";
            this.UpdateLabelPassword.Size = new System.Drawing.Size(161, 24);
            this.UpdateLabelPassword.TabIndex = 19;
            this.UpdateLabelPassword.Text = "Update password:";
            // 
            // UpdateLabelName
            // 
            this.UpdateLabelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateLabelName.AutoSize = true;
            this.UpdateLabelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabelName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateLabelName.Location = new System.Drawing.Point(96, 236);
            this.UpdateLabelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateLabelName.Name = "UpdateLabelName";
            this.UpdateLabelName.Size = new System.Drawing.Size(155, 24);
            this.UpdateLabelName.TabIndex = 20;
            this.UpdateLabelName.Text = "Update firstname:";
            // 
            // UpdateLabelDoB
            // 
            this.UpdateLabelDoB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateLabelDoB.AutoSize = true;
            this.UpdateLabelDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabelDoB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateLabelDoB.Location = new System.Drawing.Point(75, 305);
            this.UpdateLabelDoB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateLabelDoB.Name = "UpdateLabelDoB";
            this.UpdateLabelDoB.Size = new System.Drawing.Size(177, 24);
            this.UpdateLabelDoB.TabIndex = 21;
            this.UpdateLabelDoB.Text = "Update date of birth:";
            // 
            // UpdateLabelHeight
            // 
            this.UpdateLabelHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateLabelHeight.AutoSize = true;
            this.UpdateLabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabelHeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateLabelHeight.Location = new System.Drawing.Point(120, 350);
            this.UpdateLabelHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateLabelHeight.Name = "UpdateLabelHeight";
            this.UpdateLabelHeight.Size = new System.Drawing.Size(132, 24);
            this.UpdateLabelHeight.TabIndex = 22;
            this.UpdateLabelHeight.Text = "Update height:";
            // 
            // UpdateLabelWeight
            // 
            this.UpdateLabelWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateLabelWeight.AutoSize = true;
            this.UpdateLabelWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabelWeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateLabelWeight.Location = new System.Drawing.Point(52, 395);
            this.UpdateLabelWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateLabelWeight.Name = "UpdateLabelWeight";
            this.UpdateLabelWeight.Size = new System.Drawing.Size(199, 24);
            this.UpdateLabelWeight.TabIndex = 23;
            this.UpdateLabelWeight.Text = "Update starting weight:";
            // 
            // UpdateLabelActivity
            // 
            this.UpdateLabelActivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateLabelActivity.AutoSize = true;
            this.UpdateLabelActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateLabelActivity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdateLabelActivity.Location = new System.Drawing.Point(75, 443);
            this.UpdateLabelActivity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateLabelActivity.Name = "UpdateLabelActivity";
            this.UpdateLabelActivity.Size = new System.Drawing.Size(177, 24);
            this.UpdateLabelActivity.TabIndex = 24;
            this.UpdateLabelActivity.Text = "Update daily activity:";
            // 
            // UpdatePageDoB
            // 
            this.UpdatePageDoB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePageDoB.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePageDoB.CustomFormat = "dd-MM-yyyy";
            this.UpdatePageDoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePageDoB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.UpdatePageDoB.Location = new System.Drawing.Point(269, 303);
            this.UpdatePageDoB.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePageDoB.Name = "UpdatePageDoB";
            this.UpdatePageDoB.Size = new System.Drawing.Size(265, 28);
            this.UpdatePageDoB.TabIndex = 3;
            this.UpdatePageDoB.Value = new System.DateTime(2018, 5, 10, 0, 0, 0, 0);
            // 
            // UpdatePageActivity
            // 
            this.UpdatePageActivity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePageActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePageActivity.Location = new System.Drawing.Point(269, 443);
            this.UpdatePageActivity.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePageActivity.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.UpdatePageActivity.Name = "UpdatePageActivity";
            this.UpdatePageActivity.Size = new System.Drawing.Size(59, 28);
            this.UpdatePageActivity.TabIndex = 6;
            this.UpdatePageActivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UpdatePageActivityButton
            // 
            this.UpdatePageActivityButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdatePageActivityButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdatePageActivityButton.Location = new System.Drawing.Point(337, 443);
            this.UpdatePageActivityButton.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePageActivityButton.Name = "UpdatePageActivityButton";
            this.UpdatePageActivityButton.Size = new System.Drawing.Size(125, 28);
            this.UpdatePageActivityButton.TabIndex = 100000;
            this.UpdatePageActivityButton.TabStop = false;
            this.UpdatePageActivityButton.Text = "What is activity?";
            this.UpdatePageActivityButton.UseVisualStyleBackColor = true;
            this.UpdatePageActivityButton.Click += new System.EventHandler(this.UpdatePageActivityButton_Click);
            // 
            // UpdatePageForm
            // 
            this.AcceptButton = this.UpdateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(645, 567);
            this.Controls.Add(this.UpdatePageActivityButton);
            this.Controls.Add(this.UpdatePageActivity);
            this.Controls.Add(this.UpdatePageDoB);
            this.Controls.Add(this.UpdateLabelActivity);
            this.Controls.Add(this.UpdateLabelWeight);
            this.Controls.Add(this.UpdateLabelHeight);
            this.Controls.Add(this.UpdateLabelDoB);
            this.Controls.Add(this.UpdateLabelName);
            this.Controls.Add(this.UpdateLabelPassword);
            this.Controls.Add(this.UpdatePageHeight);
            this.Controls.Add(this.UpdatePageWeight);
            this.Controls.Add(this.UpdatePageName);
            this.Controls.Add(this.UpdatePagePassword);
            this.Controls.Add(this.UpdatePageLabel);
            this.Controls.Add(this.MainPageBack);
            this.Controls.Add(this.UpdateButton);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UpdatePageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateUser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterPage_Closed);
            this.Load += new System.EventHandler(this.UpdatePageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpdatePageActivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MainPageBack;
        private System.Windows.Forms.Label UpdatePageLabel;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox UpdatePagePassword;
        private System.Windows.Forms.TextBox UpdatePageName;
        private System.Windows.Forms.TextBox UpdatePageWeight;
        private System.Windows.Forms.TextBox UpdatePageHeight;
        private System.Windows.Forms.Label UpdateLabelPassword;
        private System.Windows.Forms.Label UpdateLabelName;
        private System.Windows.Forms.Label UpdateLabelDoB;
        private System.Windows.Forms.Label UpdateLabelHeight;
        private System.Windows.Forms.Label UpdateLabelWeight;
        private System.Windows.Forms.Label UpdateLabelActivity;
        private System.Windows.Forms.DateTimePicker UpdatePageDoB;
        private System.Windows.Forms.NumericUpDown UpdatePageActivity;
        private System.Windows.Forms.Button UpdatePageActivityButton;
    }
}