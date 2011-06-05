using System.Collections.Generic;
using TwitterFriendsSearcher.Core;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace TwitterFriendsSearcher.Twitter
{
    public interface ITwitterService : IUsersByKeywordsSearcher
    {
        void Tweet(string tweet);
        string GetLastTweet();
        void Follow(int userId);
        void Unfollow(int userId);
        IEnumerable<int> GetFriends(int userId);
    }
}