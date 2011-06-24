using System.Windows.Forms;

namespace TwitterFriendsSearcher.UI
{
    public partial class TwitterFriendsSearcherForm : Form
    {
        public TwitterFriendsSearcherForm(string tweet)
        {
            InitializeComponent();

            Program.TwitterFriendsService.Tweet(tweet);
        }

        public void ReadLatestTweet()
        {
            var tweet = Program.TwitterFriendsService.GetLastTweet();
            lblLastTweet.Text = tweet;
        }
    }
}
