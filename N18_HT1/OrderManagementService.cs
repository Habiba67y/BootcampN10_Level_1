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
            cashe.Set(CacheKeyConstants.Max(Orders), Orders.Max());
            return cashe.Get(CacheKeyConstants.Max(Orders));
        }
        public int Min()
        {
            cashe.Set(CacheKeyConstants.Min(Orders), Orders.Min());
            return cashe.Get(CacheKeyConstants.Min(Orders));
        }
        public int Sum()
        {
            cashe.Set(CacheKeyConstants.Sum(Orders), Orders.Sum());
            return cashe.Get(CacheKeyConstants.Sum(Orders));
        }
        public void Add(int amount)
        {
            Orders.Add(amount);
        }

    }
}
