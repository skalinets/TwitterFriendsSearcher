namespace TwitterFriendsSearcher.Twitter
{
    public class UserToken
    {
        public string AccessToken { get; private set; }
        public string AccessTokenSecret { get; private set; }

        public UserToken(string accessToken, string accessTokenSecret)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }
    }
}