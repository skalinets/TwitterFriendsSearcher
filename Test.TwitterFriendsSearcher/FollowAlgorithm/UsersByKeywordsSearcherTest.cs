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

        private ITwitterService twitterService = MockRepository.GenerateMock<ITwitterService>();

        [TestMethod]
        public void should_redirect_search_request_to_twitter_service()
        {
            var searcher = new UsersByKeywordsSearcher(twitterService);

            const string keywords = "keywords";
            var usersFound = new List<int> {1, 2};

            twitterService.Stub(x => x.FindByKeywords(keywords)).Return(usersFound);

            var result = searcher.Find(keywords);

            Assert.AreEqual(usersFound, result);
        }

    }
}