using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N18_HT1
{
    internal class OrderCacheService
    {
        private Dictionary<string, int> Cashe = new Dictionary<string, int>();
        public int Get(string key)
        {
            foreach (var c in Cashe)
            {
                if (c.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    return c.Value;
                }
            }
            return default(int);
        }
        public void Set(string key, int value)
        {
            if (!Cashe.ContainsKey(key))
            { 
                Cashe.Add(key, value);
            }
        }
        private static OrderCacheService _instance;
        private OrderCacheService()
        {
            Cashe = new Dictionary<string, int>();
        }
        public static OrderCacheService GetInstance()
        {
            if( _instance is null)
            {
                _instance = new OrderCacheService();
            }
            return _instance;
        }
    }
}
