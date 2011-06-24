using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TwitterFriendsSearcher.Twitter;
using TwitterFriendsSearcher.UI;

namespace TwitterFriendsSearcher
{
    public static class Program
    {
        public static ITwitterFriendsService TwitterFriendsService;

        public static TwitterFriendsSearcherForm MainForm { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new TwitterFriendsSearcherForm(args.Count() > 0 ? args[0] : string.Empty);

            Application.Run(MainForm);
        }
    }
}
