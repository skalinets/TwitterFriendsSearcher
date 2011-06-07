using System;

namespace TwitterFriendsSearcher.FollowAlgorithm
{
    public interface ISearchExecutor
    {
        void Execute(Action action);
    }
}