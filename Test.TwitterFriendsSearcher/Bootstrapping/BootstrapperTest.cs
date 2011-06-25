using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using TwitterFriendsSearcher.Bootstrapping;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace Test.TwitterFriendsSearcher.Bootstrapping
{
    [TestClass]
    public class BootstrapperTest
    {
        
        [TestMethod]
        public void should_wire_IncreaseFollowersServices_dependencies()
        {
            new ApplicationBootstrapper().Bootstrap();

            var increaseFollowersService = ObjectFactory.GetInstance<IncreaseFollowersService>();

            Assert.IsNotNull(increaseFollowersService);
        }

    }
}