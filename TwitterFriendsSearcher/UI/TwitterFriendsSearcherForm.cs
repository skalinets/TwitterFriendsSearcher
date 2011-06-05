using System.Windows.Forms;

namespace TwitterFriendsSearcher.UI
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
