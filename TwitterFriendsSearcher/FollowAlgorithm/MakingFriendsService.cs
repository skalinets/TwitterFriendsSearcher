using System;
using System.Collections.Generic;
using System.Linq;
using TwitterFriendsSearcher.Core;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class MakingFriendsService : IMakingFriendsService
    {
        
        public ITwitterWrapper TwitterWrapper { get; private set; }

        public MakingFriendsService(ITwitterWrapper twitterWrapper)
        {
            TwitterWrapper = twitterWrapper;
        }

        public void MakeFriendsWith(IEnumerable<int> users)
        {
            users.ToList().ForEach(TwitterWrapper.Follow);
            users.ToList().ForEach(TwitterWrapper.Unfollow);
        }
    }
}