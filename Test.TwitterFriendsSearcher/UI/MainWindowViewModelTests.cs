using System;
using System.Collections.ObjectModel;
using System.Linq;
using Ploeh.AutoFixture.Xunit;
using Rhino.Mocks;
using TwitterFriendsSearcher;
using TwitterFriendsSearcher.Twitter;
using WpfClient;
using Xunit;
using Xunit.Extensions;

namespace Test.TwitterFriendsSearcher.UI
{
    public class MainWindowViewModelTests
    {
        private readonly ITwitterFriendsService twitterFriendsService = MockRepository.GenerateStub<ITwitterFriendsService>();
        private readonly MainWindowViewModel viewModel;

        public MainWindowViewModelTests()
        {
            viewModel = new MainWindowViewModel(twitterFriendsService) {};
        }

        [Theory, AutoData]
        public void GetUsers_UserNameIsProvided_UsersIsPopulatedFromTwitterService(string searchString, TwitterUserInfo[] expectedUsers)
        {
            twitterFriendsService.Stub(_ => _.FindUsersByKeywords(searchString)).Return(expectedUsers);
            viewModel.SearchString = searchString;

            viewModel.FindUsersCommand.Execute(null); 

            Assert.Equal(expectedUsers, viewModel.Users.ToArray());
        }

        [Fact]
        public void UsersCollectionIsObservalble()
        {
            Assert.IsType<ObservableCollection<TwitterUserInfo>>(viewModel.Users);
        }
    }
}