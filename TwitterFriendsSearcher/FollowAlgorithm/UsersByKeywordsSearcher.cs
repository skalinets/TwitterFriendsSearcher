using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class UsersByKeywordsSearcher
    {
        public ITwitterFriendsService TwitterFriendsService { get; private set; }

        public UsersByKeywordsSearcher(ITwitterFriendsService twitterFriendsService)
        {
            TwitterFriendsService = twitterFriendsService;
        }

        public IEnumerable<TwitterUserInfo> Find(string keywords)
        {
            return TwitterFriendsService.FindUsersByKeywords(keywords);
        }
    }
}