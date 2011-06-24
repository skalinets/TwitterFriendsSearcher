using System;
using System.Collections.Generic;
using System.Linq;
using TweetSharp;

namespace TwitterFriendsSearcher.Twitter
{
    public class TwitterFriendsService : ITwitterFriendsService
    {
        private readonly TwitterService twitterService;

        public TwitterFriendsService(TwitterFriendsServiceParams twitterFriendsServiceParams)
        {
            twitterService = new TwitterService(twitterFriendsServiceParams.ConsumerKey, twitterFriendsServiceParams.ConsumerSecret);
            twitterService.AuthenticateWith(twitterFriendsServiceParams.AccessToken, twitterFriendsServiceParams.AccessTokenSecret);
        }

        public IEnumerable<TwitterUserInfo> FindUsersByKeywords(string keywords)
        {
            var results = twitterService.Search(keywords);

            var userNames = results.Statuses.Select(x => x.FromUserScreenName).Distinct();

            return userNames.Select(userName => new TwitterUserInfo {UserName = userName, ID = twitterService.GetUserProfileFor(userName).Id});
        }

        public void Tweet(string tweet)
        {
            twitterService.SendTweet(tweet);
        }

        public string GetLastTweet()
        {
            throw new NotImplementedException();
        }

        public void Follow(int userId)
        {
            twitterService.FollowUser(userId);
        }

        public IEnumerable<int> GetFriends(int userId)
        {
            return twitterService.ListFriendIdsOf(userId, -1);
        }

        public void Unfollow(int userId)
        {
            twitterService.UnfollowUser(userId);
        }
    }
}