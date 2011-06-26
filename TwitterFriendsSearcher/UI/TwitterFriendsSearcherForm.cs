using System;
using System.Windows.Forms;
using StructureMap;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace TwitterFriendsSearcher.UI
{
    public partial class TwitterFriendsSearcherForm : Form, ITwitterFriendsSearcherView
    {
        private TwitterFriendsSearcherPresenter presenter;

        public TwitterFriendsSearcherForm(string tweet)
        {
            InitializeComponent();

            Program.TwitterWrapper.Tweet(tweet);
        }

        public TwitterFriendsSearcherForm()
        {
            InitializeComponent();

            var increaseFollowersService = ObjectFactory.GetInstance<IIncreaseFollowersService>();
            presenter = new TwitterFriendsSearcherPresenter(this, increaseFollowersService);
        }

        public void ReadLatestTweet()
        {
            var tweet = Program.TwitterWrapper.GetLastTweet();
            lblLastTweet.Text = tweet;
        }

        public string Keywords
        {
            get { return tbKeywords.Text; }
        }

        public void ClearResultsArea()
        {
            lbUsersFollowedAtTheMoment.Items.Clear();
        }

        public void AddUserToResultsArea(int userId)
        {
            lbUsersFollowedAtTheMoment.Items.Add(userId);
            lbUsersFollowedAtTheMoment.Refresh();
        }

        public void RemoveFromResultsArea(int userId)
        {
            lbUsersFollowedAtTheMoment.Items.Remove(userId);
            lbUsersFollowedAtTheMoment.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            presenter.SearchClicked();
        }
    }
}
