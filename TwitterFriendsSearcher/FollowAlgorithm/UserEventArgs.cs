using System;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class UserEventArgs : EventArgs
    {
        public int UserId { get; set; }

        public UserEventArgs(int userId)
        {
            UserId = userId;
        }
    }
}