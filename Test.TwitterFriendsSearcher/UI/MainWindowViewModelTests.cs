using System;
using System.Linq;
using Ploeh.AutoFixture.Xunit;
using Rhino.Mocks;
using TwitterFriendsSearcher.Twitter;
using WpfClient;
using Xunit;
using Xunit.Extensions;

namespace Test.TwitterFriendsSearcher.UI
{
    public class MainWindowViewModelTests
    {
        [Theory, AutoData]
        public void GetUsers_UserNameIsProvided_UsersIsPopulatedFromTwitterService(string searchString, int[] expectedUsers)
        {
            var twitterFriendsService = MockRepository.GenerateStub<ITwitterWrapper>();
            twitterFriendsService.Stub(_ => _.FindByKeywords(searchString)).Return(expectedUsers);
            var viewModel = new MainWindowViewModel(twitterFriendsService);
            viewModel.SearchString = searchString;
            viewModel.FindUsersCommand.Execute(null); // test

            Assert.Equal(expectedUsers, viewModel.Users.ToArray());
        }
    }
}