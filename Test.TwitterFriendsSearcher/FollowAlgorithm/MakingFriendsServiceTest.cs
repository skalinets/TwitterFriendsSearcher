using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace Test.TwitterFriendsSearcher.FollowAlgorithm
{
    [TestClass]
    public class MakingFriendsServiceTest
    {

        private ITwitterWrapper twitterWrapper = MockRepository.GenerateMock<ITwitterWrapper>();

        [TestMethod]
        public void should_follow_each_user_and_unfollow_them_when_making_friends()
        {
            var users = new List<int> { 1, 2 };

            var makingFriendsService = new MakingFriendsService(twitterWrapper);

            makingFriendsService.MakeFriendsWith(users);

            twitterWrapper.AssertWasCalled(x => x.Follow(1));
            twitterWrapper.AssertWasCalled(x => x.Follow(2));

            twitterWrapper.AssertWasCalled(x => x.Unfollow(1));
            twitterWrapper.AssertWasCalled(x => x.Unfollow(2));
        }

    }
}