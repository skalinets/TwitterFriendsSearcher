using StructureMap;

namespace TwitterFriendsSearcher.Bootstrapping
{
    public class ApplicationBootstrapper
    {
        
        public void Bootstrap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new ScanningRegistry()));

            ObjectFactory.AssertConfigurationIsValid();
        }

    }
}