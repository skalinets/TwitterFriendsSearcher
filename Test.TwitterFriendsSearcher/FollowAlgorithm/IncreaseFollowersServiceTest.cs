using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TwitterFriendsSearcher.Core;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace Test.TwitterFriendsSearcher.FollowAlgorithm
{
    [TestClass]
    public class IncreaseFollowersServiceTest
    {

        private IUsersByKeywordsSearcher usersSearcher = MockRepository.GenerateMock<IUsersByKeywordsSearcher>();
        private IMakingFriendsService makingFriendsService = MockRepository.GenerateMock<IMakingFriendsService>();

        [TestMethod]
        public void should_grab_users_by_name_and_start_making_friends_process()
        {
            const string keywords = "TDD course";
            var usersForKeywords = new List<int> { 1, 2, 3 };

            var increaseFollowersService = new IncreaseFollowersService(makingFriendsService, usersSearcher);

            usersSearcher.Stub(x => x.Find(keywords)).Return(usersForKeywords);

            increaseFollowersService.IncreaseByKeywords(keywords);

            makingFriendsService.AssertWasCalled(x => x.MakeFriendsWith(usersForKeywords));
        }

        [TestMethod]
        public void should_raise_UserFollowed_when_user_is_followed()
        {
            const int userId = 3;

            var increaseFollowersService = new IncreaseFollowersService(makingFriendsService, usersSearcher);

            var isUserFollowedRaised = false;
            increaseFollowersService.UserFollowed += (sender, args) => { isUserFollowedRaised = true; };

            makingFriendsService.Raise(x => x.UserFollowed += null, this, new UserEventArgs(userId));

            Assert.IsTrue(isUserFollowedRaised);
        }

        [TestMethod]
        public void should_raise_UserUnfollowed_when_user_is_unfollowed()
        {
            const int userId = 3;

            var increaseFollowersService = new IncreaseFollowersService(makingFriendsService, usersSearcher);

            var isUserUnfollowedRaised = false;
            increaseFollowersService.UserUnfollowed += (sender, args) => { isUserUnfollowedRaised = true; };

            makingFriendsService.Raise(x => x.UserUnfollowed += null, this, new UserEventArgs(userId));

            Assert.IsTrue(isUserUnfollowedRaised);
        }
    }
}