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
            this.SuspendLayout();
            // 
            // lblLastTweet
            // 
            this.lblLastTweet.AutoSize = true;
            this.lblLastTweet.Location = new System.Drawing.Point(110, 75);
            this.lblLastTweet.Name = "lblLastTweet";
            this.lblLastTweet.Size = new System.Drawing.Size(53, 13);
            this.lblLastTweet.TabIndex = 0;
            this.lblLastTweet.Text = "no tweets";
            // 
            // TwitterFriendsSearcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblLastTweet);
            this.Name = "TwitterFriendsSearcherForm";
            this.Text = "TwitterFriendsSearcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastTweet;
    }
}

