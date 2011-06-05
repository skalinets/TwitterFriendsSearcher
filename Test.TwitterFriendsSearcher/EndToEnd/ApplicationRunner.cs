using System;
using System.Diagnostics;
using System.Threading;
using TwitterFriendsSearcher;
using TwitterFriendsSearcher.Twitter;
using White.Core;
using White.Core.UIItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.TwitterFriendsSearcher.EndToEnd
{
    public class ApplicationRunner
    {

        private Application application;

        public void Tweet(ITwitterWrapper twitterWrapper, string tweet)
        {
            new Thread(() =>
                           {
                               Program.TwitterWrapper = twitterWrapper;
                               Program.Main(tweet);
                           }).Start();

            Thread.Sleep(1000);

            var currentProcess = Process.GetCurrentProcess();
            application = Application.Attach(currentProcess.Id);
        }

        public void ReadAndDisplayRecentTweet()
        {
            if (Program.MainForm.InvokeRequired)
                Program.MainForm.Invoke(new Action(() => Program.MainForm.ReadLatestTweet()));
            else
                Program.MainForm.ReadLatestTweet();
        }

        public void ShowsTweet(string tweet)
        {
            var mainWindow = application.GetWindow("TwitterFriendsSearcher");
            var label = mainWindow.Get<Label>("lblLastTweet");

            Assert.AreEqual(tweet, label.Text);
        }
    }
}