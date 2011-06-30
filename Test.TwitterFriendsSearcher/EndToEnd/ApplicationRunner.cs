using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using StructureMap;
using Test.TwitterFriendsSearcher.TestHelpers;
using TwitterFriendsSearcher;
using TwitterFriendsSearcher.Bootstrapping;
using TwitterFriendsSearcher.Twitter;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using White.Core.UIItems.WindowItems;

namespace Test.TwitterFriendsSearcher.EndToEnd
{
    public class ApplicationRunner
    {

        private Application application;
        private Window window;

        public void Launch(ITwitterWrapper twitterWrapper)
        {
            new Thread(() =>
                           {
                               Program.TwitterWrapper = twitterWrapper;
                               Program.Main();

                           }).Start();

            var currentProcess = Process.GetCurrentProcess();
            application = Application.Attach(currentProcess.Id);

            window = application.GetWindow("TwitterFriendsSearcher");
        }

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

        public void EnterKeywords(string keywords)
        {
            var textBox = window.Get<TextBox>("tbKeywords");
            textBox.Enter(keywords);
        }

        public void ClickButton(string buttonName)
        {
            var searchButton = window.Get<Button>("btnStart");
            searchButton.Click();
        }

        public void DisplaysUserFollowed(int userId)
        {
            var listBox = window.Get<White.Core.UIItems.ListBoxItems.ListBox>("lbUsersFollowedAtTheMoment");
            listBox.Items.Any(x => x.NameMatches(userId.ToString()));
        }
    }
}