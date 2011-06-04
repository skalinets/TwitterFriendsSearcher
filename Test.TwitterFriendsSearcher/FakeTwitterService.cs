using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterFriendsSearcher;

namespace Test.TwitterFriendsSearcher
{
    public class FakeTwitterService : ITwitterService
    {

        public string LastTweet { get; private set; }
        private bool HasBeenAskedForLastTweet { get; set; }

        public void Tweet(string tweet)
        {
            LastTweet = tweet;
        }

        public string GetLastTweet()
        {
            HasBeenAskedForLastTweet = true;
            return LastTweet;
        }

        public void HasReceivedTweet(string testTweet)
        {
            Assert.AreEqual(testTweet, LastTweet);
        }

        public void HasBeenAskedForTheLastTweet()
        {
            Assert.IsTrue(HasBeenAskedForLastTweet);
        }
    }
}