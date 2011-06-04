using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitterFriendsSearcher
{
    public partial class TwitterFriendsSearcherForm : Form
    {
        public TwitterFriendsSearcherForm(string tweet)
        {
            InitializeComponent();

            Program.TwitterService.Tweet(tweet);
        }

        public void ReadLatestTweet()
        {
            var tweet = Program.TwitterService.GetLastTweet();
            lblLastTweet.Text = tweet;
        }
    }
}
