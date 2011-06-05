using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class MakingFriendsService
    {
        
        public ITwitterService TwitterService { get; private set; }

        public MakingFriendsService(ITwitterService twitterService)
        {
            TwitterService = twitterService;
        }

        public void StartMakingFriends(List<int> users)
        {
            users.ForEach(TwitterService.Follow);
            users.ForEach(TwitterService.Unfollow);
        }
    }
}