namespace TwitterFriendsSearcher.UI
{
    partial class TwitterFriendsSearcherForm
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
            this.lblLastTweet = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbKeywords = new System.Windows.Forms.TextBox();
            this.lbUsersFollowedAtTheMoment = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblLastTweet
            // 
            this.lblLastTweet.AutoSize = true;
            this.lblLastTweet.Location = new System.Drawing.Point(327, 366);
            this.lblLastTweet.Name = "lblLastTweet";
            this.lblLastTweet.Size = new System.Drawing.Size(53, 13);
            this.lblLastTweet.TabIndex = 0;
            this.lblLastTweet.Text = "no tweets";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(296, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbKeywords
            // 
            this.tbKeywords.Location = new System.Drawing.Point(13, 13);
            this.tbKeywords.Name = "tbKeywords";
            this.tbKeywords.Size = new System.Drawing.Size(277, 20);
            this.tbKeywords.TabIndex = 2;
            // 
            // lbUsersFollowedAtTheMoment
            // 
            this.lbUsersFollowedAtTheMoment.FormattingEnabled = true;
            this.lbUsersFollowedAtTheMoment.Location = new System.Drawing.Point(13, 39);
            this.lbUsersFollowedAtTheMoment.Name = "lbUsersFollowedAtTheMoment";
            this.lbUsersFollowedAtTheMoment.Size = new System.Drawing.Size(384, 316);
            this.lbUsersFollowedAtTheMoment.TabIndex = 3;
            // 
            // TwitterFriendsSearcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 397);
            this.Controls.Add(this.lbUsersFollowedAtTheMoment);
            this.Controls.Add(this.tbKeywords);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblLastTweet);
            this.Name = "TwitterFriendsSearcherForm";
            this.Text = "TwitterFriendsSearcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastTweet;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbKeywords;
        private System.Windows.Forms.ListBox lbUsersFollowedAtTheMoment;
    }
}

