using System.Collections.Generic;
using TwitterFriendsSearcher.FollowAlgorithm;
using TwitterFriendsSearcher.Twitter;

namespace TwitterFriendsSearcher.Core
{
    public interface IUsersByKeywordsSearcher
    {
        ITwitterWrapper TwitterWrapper { get; }
        ISearchExecutor SearchExecutor { get; }

        IEnumerable<int> Find(string keywords);
    }
}