using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TwitterFriendsSearcher;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.FollowAlgorithm
{
    [TestClass]
    public class UsersByKeywordsSearcherTest
    {

        private ITwitterFriendsService twitterFriendsService = MockRepository.GenerateMock<ITwitterFriendsService>();

        [TestMethod]
        public void should_redirect_search_request_to_twitter_service()
        {
            var searcher = new UsersByKeywordsSearcher(twitterFriendsService);

            const string keywords = "keywords";
            var usersFound = new List<TwitterUserInfo> {new TwitterUserInfo(), new TwitterUserInfo()};

            twitterFriendsService.Stub(x => x.FindUsersByKeywords(keywords)).Return(usersFound);

            var result = searcher.Find(keywords);

            Assert.AreEqual(usersFound, result);
        }

    }
}