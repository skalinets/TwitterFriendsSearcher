using System.Collections.Generic;

namespace TwitterFriendsSearcher.Twitter
{
    public interface ITwitterWrapper
    {
        void Tweet(string tweet);
        string GetLastTweet();
        void Follow(int userId);
        void Unfollow(int userId);
        IEnumerable<int> GetFriends(int userId);
        IEnumerable<int> FindByKeywords(string keywords);
    }
}