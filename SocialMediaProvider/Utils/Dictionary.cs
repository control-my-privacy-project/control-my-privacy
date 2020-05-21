using System.Collections.Generic;
using System.Net;

namespace SocialMediaProvider.Utils
{
    internal static class Dictionary
    {
        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue = default) =>
            dict.TryGetValue(key, out TV value) ? value : defaultValue;

    }
}
