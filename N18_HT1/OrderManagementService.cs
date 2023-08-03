using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N18_HT1
{
    internal class OrderManagementService
    {
        public List<int> Orders = new List<int>();
        public OrderCacheService cashe = OrderCacheService.GetInstance();
        public int Max()
        {
            var key = CacheKeyConstants.Max(Orders);
            if (cashe.Get(key) != default(int))
            {
                return cashe.Get(key);
            }
            var max = 0;
            foreach (var item in Orders)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            cashe.Set(CacheKeyConstants.Max(Orders), max);
            return max;
        }
        public int Min()
        {
            var key = CacheKeyConstants.Min(Orders);
            if (cashe.Get(key) != default(int))
            {
                return cashe.Get(key);
            }
            var min = Orders[0];
            foreach (var item in Orders)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            cashe.Set(CacheKeyConstants.Max(Orders), min);
            return min;
        }
        public int Sum()
        {
            var key = CacheKeyConstants.Sum(Orders);
            if (cashe.Get(key) != default(int))
            {
                return cashe.Get(key);
            }
            var sum = 0;
            foreach (var item in Orders)
            {
                sum += item;
            }
            cashe.Set(CacheKeyConstants.Max(Orders), sum);
            return sum;
        }
        public void Add(int amount)
        {
            Orders.Add(amount);
        }

    }
}
