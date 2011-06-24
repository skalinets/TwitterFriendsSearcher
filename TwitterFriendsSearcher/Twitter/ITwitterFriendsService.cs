using System.Collections.Generic;

namespace TwitterFriendsSearcher.Twitter
{
    public interface ITwitterFriendsService
    {
        void Tweet(string tweet);
        string GetLastTweet();
        void Follow(int userId);
        void Unfollow(int userId);
        IEnumerable<int> GetFriends(int userId);
        IEnumerable<TwitterUserInfo> FindUsersByKeywords(string keywords);
    }
}