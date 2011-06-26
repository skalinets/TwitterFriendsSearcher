using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.UI;

namespace Test.TwitterFriendsSearcher.UI
{
    [TestClass]
    public class TwitterFriendsSearcherPresenterTest
    {
        private static ITwitterFriendsSearcherView view;
        private static IIncreaseFollowersService increaseFollowersService;
        private static TwitterFriendsSearcherPresenter presenter;
        const string KEYWORDS = "keywords";
        
        [TestInitialize]
        public void SetUp()
        {
            view = MockRepository.GenerateMock<ITwitterFriendsSearcherView>();
            increaseFollowersService = MockRepository.GenerateMock<IIncreaseFollowersService>();
            presenter = new TwitterFriendsSearcherPresenter(view, increaseFollowersService);
        }

        [TestMethod]
        public void should_start_increasing_followers_process_using_specified_keywords()
        {
            view.Stub(x => x.Keywords).Return(KEYWORDS);

            presenter.SearchClicked();

            increaseFollowersService.AssertWasCalled(x => x.IncreaseByKeywords(KEYWORDS));
        }

        [TestMethod]
        public void should_clear_view_state_when_start_search_clicked()
        {
            presenter.SearchClicked();

            view.AssertWasCalled(x => x.ClearResultsArea());
        }

        [TestMethod]
        public void should_add_user_id_to_views_results_area_when_user_is_followed()
        {
            const int userId = 5;

            increaseFollowersService.Raise(x => x.UserFollowed += null, this, new UserEventArgs(userId));

            view.AssertWasCalled(x => x.AddUserToResultsArea(userId));
        }

        [TestMethod]
        public void should_remove_user_id_from_views_results_area_when_user_id_unfollowed()
        {
            const int userId = 5;

            increaseFollowersService.Raise(x => x.UserUnfollowed += null, this, new UserEventArgs(userId));

            view.AssertWasCalled(x => x.RemoveFromResultsArea(userId));
        }

    }
}