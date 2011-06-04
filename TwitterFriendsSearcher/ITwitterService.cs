namespace TwitterFriendsSearcher
{
    public interface ITwitterService
    {
        void Tweet(string tweet);
        string GetLastTweet();
    }
}