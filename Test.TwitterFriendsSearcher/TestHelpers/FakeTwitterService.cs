using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.TestHelpers
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

        public void Follow(int userId)
        {
            throw new NotImplementedException();
        }

        public void Unfollow(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetUserId(string screenName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetFriends(int userId)
        {
            throw new NotImplementedException();
        }

        public void HasReceivedTweet(string testTweet)
        {
            Assert.AreEqual(testTweet, LastTweet);
        }

        public void HasBeenAskedForTheLastTweet()
        {
            Assert.IsTrue(HasBeenAskedForLastTweet);
        }

        public IEnumerable<int> Find(string keywords)
        {
            throw new NotImplementedException();
        }
    }
}