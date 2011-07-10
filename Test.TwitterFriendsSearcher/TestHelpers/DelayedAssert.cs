using System;
using Bricks.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.TwitterFriendsSearcher.TestHelpers
{
    public class DelayedAssert
    {
        public static readonly int MAX_ASSERTION_TIMEOUT = 5000;

        public static void AreEqual(object expected, Func<object> getActual)
        {
            Clock.Do retrieveExpectedValue = () => getActual();
            Clock.Matched matched = actual => Equals(actual, expected);
            Clock.Expired expired = delegate { throw new AssertFailedException(); };

            var clock = new Clock(MAX_ASSERTION_TIMEOUT);
            clock.Perform(retrieveExpectedValue, matched, expired);
        }
    }
}