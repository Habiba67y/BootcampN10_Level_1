using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N27
{
    public class PersonService
    {
        private readonly EFCoreContext _context;
        public PersonService(EFCoreContext context)
        {
            _context = context;
        }
    }
}
