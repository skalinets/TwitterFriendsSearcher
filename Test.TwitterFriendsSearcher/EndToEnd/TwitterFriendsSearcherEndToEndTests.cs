using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using StructureMap;
using Test.TwitterFriendsSearcher.TestHelpers;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.EndToEnd
{

    [TestClass]
    public class TwitterFriendsSearcherEndToEndTests
    {

        private ApplicationRunner applicationRunner = new ApplicationRunner();
        //private FakeTwitterWrapper twitterWrapper = new FakeTwitterWrapper();

        [TestMethod]
        public void should_tweet_then_fetch_and_display_the_tweet()
        {
            const string keywords = "tdd course";
            const int userFound = 15;
            var foundUsers = new[] { userFound };

            var twitterWrapper = MockRepository.GenerateStub<ITwitterWrapper>();
            twitterWrapper.Stub(x => x.FindByKeywords(keywords)).Return(foundUsers);

            applicationRunner.Launch(twitterWrapper);

            applicationRunner.EnterKeywords("tdd course");
            applicationRunner.ClickButton("btnStart");

            twitterWrapper.AssertWasCalled(x => x.FindByKeywords(keywords));

            applicationRunner.DisplaysUserFollowed(userFound);

            //applicationRunner.Tweet(twitterWrapper, testTweet);
            //twitterWrapper.HasReceivedTweet(testTweet);

            //applicationRunner.ReadAndDisplayRecentTweet();
            //twitterWrapper.HasBeenAskedForTheLastTweet();

            //applicationRunner.ShowsTweet(testTweet);
        }

    }
}
