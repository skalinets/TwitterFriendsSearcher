using System;
using System.Collections.Generic;
using System.Linq;
using TweetSharp;

namespace TwitterFriendsSearcher.Twitter
{
    public class TwitterFriendsService : ITwitterService
    {
        public ApplicationToken AppToken { get; private set; }
        public UserToken UserToken { get; private set; }
        private TwitterService twitterService;

        public TwitterFriendsService(ApplicationToken appToken, UserToken userToken)
        {
            AppToken = appToken;
            UserToken = userToken;
            twitterService = new TwitterService(appToken.ConsumerKey, appToken.ConsumerSecret);
            twitterService.AuthenticateWith(userToken.AccessToken, userToken.AccessTokenSecret);
        }

        public IEnumerable<int> Find(string keywords)
        {
            var results = twitterService.Search(keywords);

            var userNames = results.Statuses.Select(x => x.FromUserScreenName).Distinct();

            return userNames.Select(userName => twitterService.GetUserProfileFor(userName).Id);
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