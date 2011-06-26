using System;
using TwitterFriendsSearcher.Core;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class IncreaseFollowersService : IIncreaseFollowersService
    {
        public event EventHandler<UserEventArgs> UserFollowed;
        public event EventHandler<UserEventArgs> UserUnfollowed;

        public IMakingFriendsService MakingFriendsService { get; private set; }
        public IUsersByKeywordsSearcher UsersByKeywordsSearcher { get; private set; }

        public IncreaseFollowersService(IMakingFriendsService makingFriendsService, IUsersByKeywordsSearcher usersByKeywordsSearcher)
        {
            MakingFriendsService = makingFriendsService;
            UsersByKeywordsSearcher = usersByKeywordsSearcher;

            MakingFriendsService.UserFollowed += UserFollowedByMakingFriendsService;
            MakingFriendsService.UserUnfollowed += UserUnfollowedByMakingFriendsService;
        }

        private void UserUnfollowedByMakingFriendsService(object sender, UserEventArgs e)
        {
            OnUserUnfollowed(e);
        }

        private void UserFollowedByMakingFriendsService(object sender, UserEventArgs e)
        {
            OnUserFollowed(e);
        }

        private void OnUserFollowed(UserEventArgs args)
        {
            if (UserFollowed != null)
                UserFollowed(this, args);
        }

        private void OnUserUnfollowed(UserEventArgs args)
        {
            if (UserUnfollowed != null)
                UserUnfollowed(this, args);
        }

        public void IncreaseByKeywords(string keywords)
        {
            var users = UsersByKeywordsSearcher.Find(keywords);
            MakingFriendsService.MakeFriendsWith(users);
        }
    }
}