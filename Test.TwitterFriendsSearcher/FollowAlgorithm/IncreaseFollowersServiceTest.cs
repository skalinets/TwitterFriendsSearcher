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
        public void should_grab_users_by_name_and_start_following_process()
        {
            const string keywords = "TDD course";
            var usersForKeywords = new List<int> {1, 2, 3};

            var increaseFollowersService = new IncreaseFollowersService(makingFriendsService, usersSearcher);

            usersSearcher.Stub(x => x.Find(keywords)).Return(usersForKeywords);

            increaseFollowersService.IncreaseByKeywords("TDD course");
            
            makingFriendsService.AssertWasCalled(x => x.MakeFriendsWith(usersForKeywords));
        }
    }
}