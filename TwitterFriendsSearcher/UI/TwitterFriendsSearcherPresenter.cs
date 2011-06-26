using System;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace TwitterFriendsSearcher.UI
{
    public class TwitterFriendsSearcherPresenter
    {
        public ITwitterFriendsSearcherView View { get; private set; }
        public IIncreaseFollowersService IncreaseFollowersService { get; private set; }

        public TwitterFriendsSearcherPresenter(ITwitterFriendsSearcherView view, IIncreaseFollowersService increaseFollowersService)
        {
            View = view;
            IncreaseFollowersService = increaseFollowersService;
            
            IncreaseFollowersService.UserFollowed += UserFollowedByIncreaseFollowersService;
            IncreaseFollowersService.UserUnfollowed += UserUnfollowedByIncreaseFollowersService;
        }

        private void UserUnfollowedByIncreaseFollowersService(object sender, UserEventArgs e)
        {
            View.RemoveFromResultsArea(e.UserId);
        }

        private void UserFollowedByIncreaseFollowersService(object sender, UserEventArgs e)
        {
            View.AddUserToResultsArea(e.UserId);
        }

        public void SearchClicked()
        {
            View.ClearResultsArea();
            IncreaseFollowersService.IncreaseByKeywords(View.Keywords);
        }
    }
}