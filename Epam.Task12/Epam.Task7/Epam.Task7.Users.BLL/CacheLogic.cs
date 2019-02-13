using System.Collections.Generic;
using Epam.Task7.Users.BLL.Interface;

namespace Epam.Task7.Users.BLL
{
    public class CacheLogic : ICacheLogic
    {
        private static Dictionary<string, object> datum = new Dictionary<string, object>();
        
        public bool Add<T>(string key, T value)
        {
            if (datum.ContainsKey(key))
            {
                return false;
            }

            datum.Add(key, value);
            return true;
        }

        public T Get<T>(string key)
        {
            if (!datum.ContainsKey(key))
            {
                return default(T);
            }

            return (T)datum[key];
        }

        public bool Delete(string key)
        {
            return datum.Remove(key);
        }
    }
}
