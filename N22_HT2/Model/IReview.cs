using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N22_HT2.Model
{
    public interface IReview
    {
        Guid Id { get; set; }
        byte Star { get; set; }
        string Message { get; set; }
    }
}
