using System;
using TwitterFriendsSearcher.Core;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class IncreaseFollowersService
    {
        public IMakingFriendsService MakingFriendsService { get; private set; }
        public IUsersByKeywordsSearcher UsersByKeywordsSearcher { get; private set; }

        public IncreaseFollowersService(IMakingFriendsService makingFriendsService, IUsersByKeywordsSearcher usersByKeywordsSearcher)
        {
            MakingFriendsService = makingFriendsService;
            UsersByKeywordsSearcher = usersByKeywordsSearcher;
        }

        public void IncreaseByKeywords(string keywords)
        {
            var users = UsersByKeywordsSearcher.Find(keywords);
            MakingFriendsService.MakeFriendsWith(users);
        }
    }
}