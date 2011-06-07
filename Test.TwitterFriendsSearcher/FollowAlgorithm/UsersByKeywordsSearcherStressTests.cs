using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.FollowAlgorithm
{
    [TestClass]
    public class UsersByKeywordsSearcherStressTests
    {

        private ITwitterWrapper twitterWrapper;
        private ISearchExecutor executor;

        private UsersByKeywordsSearcher searcher;
        private int NUMBER_OF_SEARCHES = 10;

        private ManualResetEvent wait;

        [TestInitialize]
        public void SetUp()
        {
            twitterWrapper = MockRepository.GenerateStub<ITwitterWrapper>();
            twitterWrapper.Stub(x => x.FindByKeywords(Arg<string>.Is.Anything)).Return(new List<int> { 1, 2 });
            executor = new MultipleThreadsExecutor();
        }

        [TestMethod]
        public void should_raise_SearchCompleted_only_once_regardless_of_threads_number()
        {
            searcher = new UsersByKeywordsSearcher(twitterWrapper, executor);

            for (int i = 0; i < NUMBER_OF_SEARCHES; i++)
            {
                wait = new ManualResetEvent(false);
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            int searchCompletedRaisedTimes = 0;

            searcher.SearchCompleted += (sender, args) =>
                                            {
                                                Interlocked.Increment(ref searchCompletedRaisedTimes);
                                                wait.Set();
                                            };

            searcher.Find(Keywords());

            Assert.IsTrue(wait.WaitOne(1000));
            Assert.AreEqual(1, searchCompletedRaisedTimes);
        }

        private string[] Keywords()
        {
            return new List<string> { "1", "2", "3", "4" }.ToArray();
        }

    }
}