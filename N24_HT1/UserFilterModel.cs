using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public class UserFilterModel: FilterModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public override int PageSize { get; set; }
        public override int PageToken { get; set; }
        public UserFilterModel(string? firstName, string? lastName, int pageToken, int pageSize)
        {
            FirstName = firstName;
            LastName = lastName;
            PageToken = pageToken;
            PageSize = pageSize;
        }
    }
}
