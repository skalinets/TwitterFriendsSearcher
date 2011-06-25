namespace TwitterFriendsSearcher.Twitter
{
    public class ApplicationToken
    {
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }

        public ApplicationToken()
            :this(TwitterAccess.ConsumerKey, TwitterAccess.ConsumerSecret)
        {
        }

        public ApplicationToken(string consumerKey, string consumerSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
        }
    }
}