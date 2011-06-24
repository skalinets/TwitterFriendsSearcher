using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class MakingFriendsService
    {
        
        public ITwitterFriendsService TwitterFriendsService { get; private set; }

        public MakingFriendsService(ITwitterFriendsService twitterFriendsService)
        {
            TwitterFriendsService = twitterFriendsService;
        }

        public void StartMakingFriends(List<int> users)
        {
            users.ForEach(TwitterFriendsService.Follow);
            users.ForEach(TwitterFriendsService.Unfollow);
        }
    }
}