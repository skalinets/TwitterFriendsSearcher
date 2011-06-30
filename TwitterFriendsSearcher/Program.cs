using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StructureMap;
using TwitterFriendsSearcher.Bootstrapping;
using TwitterFriendsSearcher.Twitter;
using TwitterFriendsSearcher.UI;

namespace TwitterFriendsSearcher
{
    public static class Program
    {
        public static ITwitterWrapper TwitterWrapper;

        public static TwitterFriendsSearcherForm MainForm { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(params string[] args)
        {
            new ApplicationBootstrapper().Bootstrap();

            if(TwitterWrapper != null)
                ObjectFactory.Inject(TwitterWrapper);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new TwitterFriendsSearcherForm();

            Application.Run(MainForm);
        }
    }
}
