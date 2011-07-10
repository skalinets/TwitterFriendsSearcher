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

        [TestInitialize]
        public void SetUp()
        {
            applicationRunner.Launch();
        }

        [TestCleanup]
        public void TearDown()
        {
            applicationRunner.StopApplication();
        }

        [TestMethod]
        public void should_display_the_user_returned_from_Twitter_when_entered_keywords_and_clicked_search()
        {
            applicationRunner.EnterKeywords("tdd course");
            applicationRunner.ClickButton("btnStart");

            DelayedAssert.AreEqual(true, () => applicationRunner.DisplaysAtLeastOneFollowedUser());
        }

    }
}
