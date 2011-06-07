using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class UsersByKeywordsSearcher
    {
        public ITwitterWrapper TwitterWrapper { get; private set; }
        public ISearchExecutor SearchExecutor { get; private set; }

        private int asychronousSearchesInProgress;
        private IEnumerable<int> foundUsers;

        public UsersByKeywordsSearcher(ITwitterWrapper twitterWrapper, ISearchExecutor searchExecutor)
        {
            TwitterWrapper = twitterWrapper;
            SearchExecutor = searchExecutor;
        }

        public IEnumerable<int> Find(string keywords)
        {
            return TwitterWrapper.FindByKeywords(keywords);
        }

        public event EventHandler<SearchCompletedEventArgs> SearchCompleted;

        public void OnSearchCompleted(SearchCompletedEventArgs e)
        {
            EventHandler<SearchCompletedEventArgs> handler = SearchCompleted;
            if (handler != null) handler(this, e);
        }

        public void Find(params string[] keywords)
        {
            foundUsers = new List<int>();
            asychronousSearchesInProgress = keywords.Length;
            keywords.ToList().ForEach(x => StartSearching(TwitterWrapper, x));
        }

        private void StartSearching(ITwitterWrapper twitterWrapper, string keywords)
        {
            SearchExecutor.Execute(() => Search(twitterWrapper, keywords));
        }

        private void Search(ITwitterWrapper twitterWrapper, string keywords)
        {
            var searchResult = twitterWrapper.FindByKeywords(keywords);

            lock (this)
            {

                Interlocked.Decrement(ref asychronousSearchesInProgress);

                foundUsers = foundUsers.Union(searchResult);

            }
            if(asychronousSearchesInProgress == 0)
                OnSearchCompleted(new SearchCompletedEventArgs(foundUsers));
        }
    }
}