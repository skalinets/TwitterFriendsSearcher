using System;
using Bricks.Core;

namespace TwitterFriendsSearcher.Runner
{
    internal static class DelayedSearcher
    {
        public static object FindUiElement(Func<object> find)
        {
            return FindUiElement(find, 5000, x => x != null, () => null);
        }

        private static object FindUiElement(Func<object> find, int busyTimeOut, Clock.Matched matched, Clock.Expired expired)
        {
            var doSearch = new Clock.Do(() => SwallowAllExceptions(find, null));

            var clock = new Clock(busyTimeOut);

            return clock.Perform(doSearch, matched, expired);
        }

        private static object SwallowAllExceptions(Func<object> find, object returnValueIfExceptionThrown)
        {
            try
            {
                return find();
            }
            catch (Exception)
            {
                return returnValueIfExceptionThrown;
            }
        }
    }
}