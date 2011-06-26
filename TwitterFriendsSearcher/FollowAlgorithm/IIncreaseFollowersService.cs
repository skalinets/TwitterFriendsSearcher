using System;
using TwitterFriendsSearcher.Core;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public interface IIncreaseFollowersService
    {
        event EventHandler<UserEventArgs> UserFollowed;
        event EventHandler<UserEventArgs> UserUnfollowed;

        IMakingFriendsService MakingFriendsService { get; }
        IUsersByKeywordsSearcher UsersByKeywordsSearcher { get; }
        void IncreaseByKeywords(string keywords);
    }
}