using System.Collections.ObjectModel;
using System.Linq;
using TwitterFriendsSearcher.Twitter;

namespace WpfClient
{
    public class MainWindowViewModel
    {
        private readonly ITwitterWrapper twitterFriendsService;
        private readonly ObservableCollection<int> users = new ObservableCollection<int>();
        private string searchString;

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(ITwitterWrapper twitterFriendsService)
        {
            this.twitterFriendsService = twitterFriendsService;
        }

        public ObservableCollection<int> Users
        {
            get { return users; }
        }

        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; }
        }

        public void FindUsers()
        {
            users.Clear();
            twitterFriendsService.FindByKeywords(SearchString).ToList().ForEach(users.Add);
        }
    }
}