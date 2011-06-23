using System.Collections.Generic;
using TwitterFriendsSearcher.Twitter;

namespace WpfClient
{
    public class MainWindowViewModel
    {
        private readonly ITwitterWrapper twitterFriendsService;
        private IEnumerable<int> users;

        public MainWindowViewModel(ITwitterWrapper twitterFriendsService)
        {
            this.twitterFriendsService = twitterFriendsService;
        }

        public IEnumerable<int> Users
        {
            get { return users; }
        }

        public void FindUsers(string searchString)
        {
            users = twitterFriendsService.FindByKeywords(searchString);
        }
    }
}