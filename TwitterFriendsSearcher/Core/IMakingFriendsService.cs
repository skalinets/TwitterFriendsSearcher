using System.Collections.Generic;

namespace TwitterFriendsSearcher.Core
{
    public interface IMakingFriendsService
    {
        void MakeFriendsWith(IEnumerable<int> users);
    }
}