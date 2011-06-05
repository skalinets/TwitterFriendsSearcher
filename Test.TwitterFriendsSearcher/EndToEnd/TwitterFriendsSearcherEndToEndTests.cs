using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.TwitterFriendsSearcher.TestHelpers;

namespace Test.TwitterFriendsSearcher.EndToEnd
{
    
    [TestClass]
    public class TwitterFriendsSearcherEndToEndTests
    {

        private ApplicationRunner applicationRunner = new ApplicationRunner();
        private FakeTwitterWrapper twitterWrapper = new FakeTwitterWrapper();

        [TestMethod]
        public void should_tweet_then_fetch_and_display_the_tweet()
        {
            const string testTweet = "Test tweet";

            applicationRunner.Tweet(twitterWrapper, testTweet);
            twitterWrapper.HasReceivedTweet(testTweet);

            applicationRunner.ReadAndDisplayRecentTweet();
            twitterWrapper.HasBeenAskedForTheLastTweet();

            applicationRunner.ShowsTweet(testTweet);
        }

    }
}
