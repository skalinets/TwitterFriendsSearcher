namespace TwitterFriendsSearcher.Twitter
{
    public class TwitterFriendsServiceParams
    {
        public string ConsumerKey { get; private set; }
        public string ConsumerSecret { get; private set; }
        public string AccessToken { get; private set; }
        public string AccessTokenSecret { get; private set; }

        public TwitterFriendsServiceParams(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }

        public static TwitterFriendsServiceParams GetTestParams()
        {
            return new TwitterFriendsServiceParams(TwitterAccess.ConsumerKey, TwitterAccess.ConsumerSecret, TwitterAccess.AccessToken, TwitterAccess.AccessTokenSecret);
        }
    }
}