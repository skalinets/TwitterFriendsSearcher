using System.Windows.Forms;

namespace TwitterFriendsSearcher.UI
{
    public partial class TwitterFriendsSearcherForm : Form
    {
        public TwitterFriendsSearcherForm(string tweet)
        {
            InitializeComponent();

            Program.TwitterWrapper.Tweet(tweet);
        }

        public void ReadLatestTweet()
        {
            var tweet = Program.TwitterWrapper.GetLastTweet();
            lblLastTweet.Text = tweet;
        }
    }
}
