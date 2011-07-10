using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using Rhino.Mocks;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.Runner
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var hostingThread = new Thread(HostGetServices) { IsBackground = false };
            hostingThread.Start();

            RunTwitterFriendsSearcher();
        }

        private static void RunTwitterFriendsSearcher()
        {
            var twitterWrapper = MockRepository.GenerateStub<ITwitterWrapper>();
            twitterWrapper.Expect(x => x.FindByKeywords(null)).IgnoreArguments().Return(new[] { 123 });

            TwitterFriendsSearcher.Program.TwitterWrapper = twitterWrapper;
            TwitterFriendsSearcher.Program.Main();
        }

        private static void HostGetServices()
        {
            var serviceInstance = new TwitterFriendsSearcherUiInfoProvider(TwitterFriendsSearcher.Program.MainForm);
            using (var host = new ServiceHost(serviceInstance, new[] { new Uri("http://localhost:8083") }))
            {
                var behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(behavior);

                host.AddServiceEndpoint(typeof(ITwitterFriendsSearcherUiInfoProvider), new BasicHttpBinding(),
                                        "TwitterFriendsSearcherUiInfoProvider");

                host.AddServiceEndpoint(typeof(IMetadataExchange), new BasicHttpBinding(), "MEX");

                host.Open();

                Console.WriteLine("Service is ready, press any key to terminate");
                Console.ReadLine();
            }
        }
    }
}
