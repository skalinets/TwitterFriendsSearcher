using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.Core
{
    public interface IMakingFriendsService
    {
        event EventHandler<UserEventArgs> UserFollowed;
        event EventHandler<UserEventArgs> UserUnfollowed;
        
        ITwitterWrapper TwitterWrapper { get; }

        void MakeFriendsWith(IEnumerable<int> users);
    }
}