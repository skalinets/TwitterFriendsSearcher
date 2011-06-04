using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.TwitterFriendsSearcher
{
    
    [TestClass]
    public class TwitterFriendsSearcherEndToEndTests
    {

        private ApplicationRunner applicationRunner = new ApplicationRunner();
        private FakeTwitterService twitterService = new FakeTwitterService();

        [TestMethod]
        public void shouldTweetTheFetchAndDisplayTheTweet()
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
