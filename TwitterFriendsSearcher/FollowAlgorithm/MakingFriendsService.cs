using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public event EventHandler<UserEventArgs> UserFollowed;
        public event EventHandler<UserEventArgs> UserUnfollowed;

        public void OnUserUnfollowed(UserEventArgs e)
        {
            if (UserUnfollowed != null) UserUnfollowed(this, e);
        }

        public void OnUserFollowed(UserEventArgs args)
        {
            if (UserFollowed != null) UserFollowed(this, args);
        }

        public void MakeFriendsWith(IEnumerable<int> users)
        {
            users.ToList().ForEach(x =>
            {
                TwitterWrapper.Follow(x);
                OnUserFollowed(new UserEventArgs(x));
            });

            Thread.Sleep(2000);

            users.ToList().ForEach(x =>
            {
                TwitterWrapper.Unfollow(x);
                OnUserUnfollowed(new UserEventArgs(x));
            });
        }
    }
}