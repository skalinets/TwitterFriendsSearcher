using System;
using System.Collections.Generic;
using System.Linq;
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
            var twitterFriendsService = new TwitterFriendsService(appToken, userToken);

            var friendId = GetRandomFriendOf(twitterFriendsService, TwitterAccess.UserId);

            twitterFriendsService.Unfollow(friendId);

            Assert.IsFalse(twitterFriendsService.GetFriends(TwitterAccess.UserId).Contains(friendId));

            twitterFriendsService.Follow(friendId);

            Assert.IsTrue(twitterFriendsService.GetFriends(TwitterAccess.UserId).Contains(friendId));
        }

        private int GetRandomFriendOf(TwitterFriendsService twitterFriendsService, int userId)
        {
            var friendsIds = twitterFriendsService.GetFriends(userId);

            return friendsIds.First();
        }
    }
}