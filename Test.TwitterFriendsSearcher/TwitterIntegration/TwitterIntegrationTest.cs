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

        private ApplicationToken appToken = new ApplicationToken(TwitterAccess.ConsumerKey, TwitterAccess.ConsumerSecret);
        private UserToken userToken = new UserToken(TwitterAccess.AccessToken, TwitterAccess.AccessTokenSecret);

        [TestMethod]
        public void should_follow_and_unfollow_user_when_asked()
        {
            var twitterFriendsService = new TwitterWrapper(appToken, userToken);

            var friendId = GetRandomFriendOf(twitterFriendsService, TwitterAccess.UserId);

            twitterFriendsService.Unfollow(friendId);

            Assert.IsFalse(twitterFriendsService.GetFriends(TwitterAccess.UserId).Contains(friendId));

            twitterFriendsService.Follow(friendId);

            Assert.IsTrue(twitterFriendsService.GetFriends(TwitterAccess.UserId).Contains(friendId));
        }

        [TestMethod]
        public void should_return_authors_of_tweets_that_match_keywords_when_searching_for_users_by_keywords()
        {
            var twitterFriendsService = new TwitterWrapper(appToken, userToken);

            var users = twitterFriendsService.FindByKeywords("tdd course");

            Assert.IsTrue(users.Count() > 0);
        }

        private int GetRandomFriendOf(TwitterWrapper twitterWrapper, int userId)
        {
            var friendsIds = twitterWrapper.GetFriends(userId);

            return friendsIds.First();
        }
    }
}