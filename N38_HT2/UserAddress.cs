using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N38_HT2
{
    public class UserAddress
    {
        public Guid UserId { get; set; }
        public string TownName { get; set; }
        public string RoadName { get; set; }
        public string HouseNumber { get; set; }
    }
}
