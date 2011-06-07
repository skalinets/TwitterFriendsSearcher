using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Test.TwitterFriendsSearcher.TestHelpers;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.FollowAlgorithm
{
    [TestClass]
    public class UsersByKeywordsSearcherTest
    {

        private ITwitterWrapper twitterWrapper = MockRepository.GenerateMock<ITwitterWrapper>();

        const string keyword1 = "keyword 1";
        const string keyword2 = "keyword 2";

        private List<int> users1 = new List<int> { 1, 2 };
        private List<int> users2 = new List<int> { 2, 3 };
        private SynchronousExecutor searchExecutor;

        [TestMethod]
        public void should_redirect_search_request_to_twitter_service()
        {
            var searcher = new UsersByKeywordsSearcher(twitterWrapper, null);

            const string keywords = "keywords";
            var usersFound = new List<int> {1, 2};

            twitterWrapper.Stub(x => x.FindByKeywords(keywords)).Return(usersFound);

            var result = searcher.Find(keywords);

            Assert.AreEqual(usersFound, result);
        }

        [TestMethod]
        public void should_search_for_multiple_keywords_via_search_executor()
        {
            searchExecutor = new SynchronousExecutor();
            var searcher = new UsersByKeywordsSearcher(twitterWrapper, searchExecutor);

            twitterWrapper.Stub(x => x.FindByKeywords(keyword1)).Return(users1);
            twitterWrapper.Stub(x => x.FindByKeywords(keyword2)).Return(users2);

            bool isSearchCompletedRaised = false;

            searcher.SearchCompleted += (sender, args) =>
            {
                CollectionAssert.AreEqual(new[] { 1, 2, 3 }, args.Users.ToArray());
                isSearchCompletedRaised = true;
            };

            searcher.Find(keyword1, keyword2);
            searchExecutor.ExecuteUntilIdle();

            Assert.IsTrue(isSearchCompletedRaised);
        }



    }
}