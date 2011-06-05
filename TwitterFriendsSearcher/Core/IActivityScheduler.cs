using System;

namespace TwitterFriendsSearcher.Core
{
    public interface IActivityScheduler
    {
        void Schedule(Action action, int interval);
    }
}