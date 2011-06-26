using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace TwitterFriendsSearcher.Core
{
    public interface IMakingFriendsService
    {
        event EventHandler<UserEventArgs> UserFollowed;
        event EventHandler<UserEventArgs> UserUnfollowed;

        void MakeFriendsWith(IEnumerable<int> users);
    }
}