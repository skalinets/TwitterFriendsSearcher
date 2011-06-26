using StructureMap.Configuration.DSL;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.Bootstrapping
{
    public class ScanningRegistry : Registry
    {

        public ScanningRegistry()
        {
            Scan(x =>
                     { 
                         x.AssemblyContainingType(typeof(ScanningRegistry));
                         x.WithDefaultConventions();

                         x.ExcludeNamespace("TwitterFriendsSearcher.UI");
                     });

            SelectConstructor(() => new ApplicationToken());
            SelectConstructor(() => new UserToken());

            For<ITwitterWrapper>().Use<TwitterWrapper>().OnCreation(x => x.Authenticate(new UserToken()));

            For<ISearchExecutor>().Use<MultipleThreadsExecutor>();
        }

    }
}