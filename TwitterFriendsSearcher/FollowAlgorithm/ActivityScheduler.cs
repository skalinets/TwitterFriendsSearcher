using System;
using System.Threading;
using TwitterFriendsSearcher.Core;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public class ActivityScheduler : IActivityScheduler
    {
        public void Schedule(Action action, int interval)
        {
            new Timer(o => action(), null, interval, Timeout.Infinite);
        }
    }
}