using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class UsersByKeywordsSearcher
    {
        public ITwitterService TwitterService { get; private set; }

        public UsersByKeywordsSearcher(ITwitterService twitterService)
        {
            TwitterService = twitterService;
        }

        public IEnumerable<int> Find(string keywords)
        {
            return TwitterService.FindByKeywords(keywords);
        }
    }
}