using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.TwitterFriendsSearcher.TestHelpers;

namespace Test.TwitterFriendsSearcher.EndToEnd
{
    
    [TestClass]
    public class TwitterFriendsSearcherEndToEndTests
    {

        private ApplicationRunner applicationRunner = new ApplicationRunner();
        private FakeTwitterFriendsService twitterFriendsService = new FakeTwitterFriendsService();

        [TestMethod]
        public void should_tweet_then_fetch_and_display_the_tweet()
        {
            const string testTweet = "Test tweet";

            applicationRunner.Tweet(twitterFriendsService, testTweet);
            twitterFriendsService.HasReceivedTweet(testTweet);

            applicationRunner.ReadAndDisplayRecentTweet();
            twitterFriendsService.HasBeenAskedForTheLastTweet();

            applicationRunner.ShowsTweet(testTweet);
        }

    }
}
