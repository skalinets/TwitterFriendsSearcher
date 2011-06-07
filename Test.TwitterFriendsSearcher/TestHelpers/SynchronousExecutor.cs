using System;
using System.Collections.Generic;
using TwitterFriendsSearcher.FollowAlgorithm;

namespace Test.TwitterFriendsSearcher.TestHelpers
{
    public class SynchronousExecutor : ISearchExecutor
    {
        private List<Action> actionsToExecute = new List<Action>();
        
        public void ExecuteUntilIdle()
        {
            actionsToExecute.ForEach(x => x());
        }

        public void Execute(Action action)
        {
            actionsToExecute.Add(action);
        }
    }
}