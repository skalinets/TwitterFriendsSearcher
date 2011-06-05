using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.FollowAlgorithm
{
    [TestClass]
    public class UsersByKeywordsSearcherTest
    {

        private ITwitterWrapper twitterWrapper = MockRepository.GenerateMock<ITwitterWrapper>();

        [TestMethod]
        public void should_redirect_search_request_to_twitter_service()
        {
            var searcher = new UsersByKeywordsSearcher(twitterWrapper);

            const string keywords = "keywords";
            var usersFound = new List<int> {1, 2};

            twitterWrapper.Stub(x => x.FindByKeywords(keywords)).Return(usersFound);

            var result = searcher.Find(keywords);

            Assert.AreEqual(usersFound, result);
        }

        [TestMethod]
        public void should_search_for_all_keywords()
        {
            var searcher = new UsersByKeywordsSearcher(twitterWrapper);

        }

    }
}