using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class UsersByKeywordsSearcher
    {
        public ITwitterWrapper TwitterWrapper { get; private set; }

        public UsersByKeywordsSearcher(ITwitterWrapper twitterWrapper)
        {
            TwitterWrapper = twitterWrapper;
        }

        public IEnumerable<int> Find(string keywords)
        {
            return TwitterWrapper.FindByKeywords(keywords);
        }
    }
}