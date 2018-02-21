using System.Collections.Generic;

namespace Kardf.Extensions
{
    public static class CollectionExtension
    {
        public static T Value<T>(this IDictionary<string, object> dictionary, string key, T defValue = default(T))
        {
            if (dictionary.ContainsKey(key))
            {
                return (T)dictionary[key];
            }

            return defValue;
        }
    }
}
