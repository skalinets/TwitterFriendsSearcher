using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.TwitterIntegration
{
    [TestClass]
    public class TwitterIntegrationTest
    {
        private readonly TwitterFriendsServiceParams twitterFriendsServiceParams;

        public TwitterIntegrationTest()
        {
            twitterFriendsServiceParams = TwitterFriendsServiceParams.GetTestParams();
        }

        [TestMethod]
        public void should_follow_and_unfollow_user_when_asked()
        {
            var twitterFriendsService = new TwitterFriendsService(twitterFriendsServiceParams);

            var friendId = GetRandomFriendOf(twitterFriendsService, TwitterAccess.UserId);

            twitterFriendsService.Unfollow(friendId);

            Assert.IsFalse(twitterFriendsService.GetFriends(TwitterAccess.UserId).Contains(friendId));

            twitterFriendsService.Follow(friendId);

            Assert.IsTrue(twitterFriendsService.GetFriends(TwitterAccess.UserId).Contains(friendId));
        }

        [TestMethod]
        public void should_return_authors_of_tweets_that_match_keywords_when_searching_for_users_by_keywords()
        {
            var twitterFriendsService = new TwitterFriendsService(twitterFriendsServiceParams);

            var users = twitterFriendsService.FindUsersByKeywords("tdd course");

//            users.ToList().ForEach(Console.WriteLine);

            Assert.IsTrue(users.Count() > 0);
        }

        private int GetRandomFriendOf(TwitterFriendsService twitterFriendsService, int userId)
        {
            var friendsIds = twitterFriendsService.GetFriends(userId);

            return friendsIds.First();
        }
    }
}