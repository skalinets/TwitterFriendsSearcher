using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace Test.TwitterFriendsSearcher.FollowAlgorithm
{
    [TestClass]
    public class ActivitySchedulerTest
    {
        
        [TestMethod]
        public void should_execute_specified_action_after_the_specified_timeframe_has_passed()
        {
            var activityScheduler = new ActivityScheduler();

            var shouldBe20 = 10;

            activityScheduler.Schedule(() => shouldBe20 = 20, 500);

            Assert.AreNotEqual(20, shouldBe20);

            Thread.Sleep(1000);

            Assert.AreEqual(20, shouldBe20);
        }

    }
}