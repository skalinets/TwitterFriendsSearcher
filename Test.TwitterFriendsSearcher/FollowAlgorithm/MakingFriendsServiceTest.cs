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

        [TestMethod]
        public void should_raise_UserFollowed_when_the_user_is_followed()
        {
            var users = new List<int> { 1 };

            var makingFriendsService = new MakingFriendsService(twitterWrapper);

            var isUserFollowedRaised = false;

            makingFriendsService.UserFollowed += (sender, e) => { isUserFollowedRaised = true; };

            makingFriendsService.MakeFriendsWith(users);

            Assert.IsTrue(isUserFollowedRaised);
        }

        [TestMethod]
        public void should_raise_UserUnfollowed_when_the_user_is_unfollowed()
        {
            var users = new List<int> { 1 };

            var makingFriendsService = new MakingFriendsService(twitterWrapper);

            var isUserUnfollowedRaised = false;

            makingFriendsService.UserUnfollowed += (sender, e) => { isUserUnfollowedRaised = true; };

            makingFriendsService.MakeFriendsWith(users);

            Assert.IsTrue(isUserUnfollowedRaised);
        }

    }
}