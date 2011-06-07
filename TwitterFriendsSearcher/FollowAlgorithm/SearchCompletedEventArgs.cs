using System;
using System.Collections.Generic;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class SearchCompletedEventArgs : EventArgs
    {

        public SearchCompletedEventArgs(IEnumerable<int> users)
        {
            Users = users;
        }

        public IEnumerable<int> Users { get; private set; }
    }
}