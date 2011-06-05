using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class MakingFriendsService
    {
        
        public ITwitterWrapper TwitterWrapper { get; private set; }

        public MakingFriendsService(ITwitterWrapper twitterWrapper)
        {
            TwitterWrapper = twitterWrapper;
        }

        public void StartMakingFriends(List<int> users)
        {
            users.ForEach(TwitterWrapper.Follow);
            users.ForEach(TwitterWrapper.Unfollow);
        }
    }
}