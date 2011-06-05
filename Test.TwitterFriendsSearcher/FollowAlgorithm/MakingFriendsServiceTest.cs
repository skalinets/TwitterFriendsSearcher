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

        private ITwitterService twitterService = MockRepository.GenerateMock<ITwitterService>();

        [TestMethod]
        public void should_follow_each_user_and_unfollow_them_when_making_friends()
        {
            var users = new List<int> { 1, 2 };

            var makingFriendsService = new MakingFriendsService(twitterService);

            makingFriendsService.StartMakingFriends(users);

            twitterService.AssertWasCalled(x => x.Follow(1));
            twitterService.AssertWasCalled(x => x.Follow(2));

            twitterService.AssertWasCalled(x => x.Unfollow(1));
            twitterService.AssertWasCalled(x => x.Unfollow(2));
        }

    }
}