using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.TwitterFriendsSearcher.TestHelpers;

namespace Test.TwitterFriendsSearcher.EndToEnd
{
    
    [TestClass]
    public class TwitterFriendsSearcherEndToEndTests
    {

        private ApplicationRunner applicationRunner = new ApplicationRunner();
        private FakeTwitterService twitterService = new FakeTwitterService();

        [TestMethod]
        public void should_tweet_then_fetch_and_display_the_tweet()
        {
            const string testTweet = "Test tweet";

            applicationRunner.Tweet(twitterService, testTweet);
            twitterService.HasReceivedTweet(testTweet);

            applicationRunner.ReadAndDisplayRecentTweet();
            twitterService.HasBeenAskedForTheLastTweet();

            applicationRunner.ShowsTweet(testTweet);
        }

    }
}
