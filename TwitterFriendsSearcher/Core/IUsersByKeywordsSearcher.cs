using System.Collections.Generic;

namespace TwitterFriendsSearcher.Core
{
    public interface IUsersByKeywordsSearcher
    {
        IEnumerable<int> Find(string keywords);
    }
}