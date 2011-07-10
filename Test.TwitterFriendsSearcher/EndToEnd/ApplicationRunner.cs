using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using Test.TwitterFriendsSearcher.TwitterFriendsSearcherUiProvider;
using TwitterFriendsSearcher;
using TwitterFriendsSearcher.Twitter;
using White.Core;
using White.Core.InputDevices;
using White.Core.UIItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using White.Core.UIItems.WindowItems;

namespace Test.TwitterFriendsSearcher.EndToEnd
{
    public class ApplicationRunner
    {

        private Application application;
        private Keyboard keyboard;
        private Mouse mouse;
        private Process twitterFriendsSearcherProccess;

        public void Launch()
        {
            keyboard = Keyboard.Instance;
            mouse = Mouse.Instance;

            LaunchTwitterFriendsSearcherAndHostTheService();

            twitterFriendsSearcherProccess = Process.GetProcessesByName("TwitterFriendsSearcher.Runner")[0];

            application = Application.Attach(twitterFriendsSearcherProccess.Id);
        }

        private void LaunchTwitterFriendsSearcherAndHostTheService()
        {
            Process.Start(@"..\..\..\..\..\TwitterFriendsSearcher.Runner\bin\Debug\TwitterFriendsSearcher.Runner.exe");

            // give it a chance to run and host a service
            Thread.Sleep(10000);
        }

        public void EnterKeywords(string keywords)
        {
            using (var serviceClient = new TwitterFriendsSearcherUiInfoProviderClient())
            {
                var center = serviceClient.GetTextBoxCenterByName("tbKeywords");
                mouse.Click(new Point(center.X, center.Y));
            }

            keyboard.Enter(keywords);
        }

        public void ClickButton(string buttonName)
        {
            using(var serviceClient = new TwitterFriendsSearcherUiInfoProviderClient())
            {
                var center = serviceClient.GetButtonCenterByName(buttonName);
                mouse.Location = new Point(center.X, center.Y);
                mouse.Click();
            }
        }

        public bool DisplaysAtLeastOneFollowedUser()
        {
            using(var serviceClient = new TwitterFriendsSearcherUiInfoProviderClient())
            {
                return serviceClient.GetListBoxInfo("lbUsersFollowedAtTheMoment").Items.Length > 0;
            }
        }

        public void StopApplication()
        {
            application.Kill();
            try
            {
                twitterFriendsSearcherProccess.Kill();
            }
            catch
            {
            }

        }
    }
}