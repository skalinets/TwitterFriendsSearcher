namespace TwitterFriendsSearcher.Twitter
{
    public static class TwitterAccess
    {

        static TwitterAccess()
        {
            ConsumerKey = "L7OZz7o2w6iBd9hF37cQ";
            ConsumerSecret = "o07YboCFHISbkSgDg7l44AyzHyqJSCeAoK602dw6ic";
            AccessToken = "311372276-G29wjAunNTogOT48Q5nnUIpNnyuvTtUOen53mxjY";
            AccessTokenSecret = "X0J1wUvBT6J1yJ191nyJwl72Fz3XMcmD1eQJyyXU";
            UserId = 311372276;
        }

        public static string ConsumerKey
        {
            get;
            private set;
        }

        public static string ConsumerSecret
        {
            get;
            private set;
        }

        public static string AccessToken
        {
            get;
            private set;
        }

        public static string AccessTokenSecret
        {
            get;
            private set;
        }

        public static int UserId { get; private set; }
    }
}