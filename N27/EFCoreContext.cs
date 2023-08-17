using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N27
{
    public class EFCoreContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres;");
        public DbSet<Person> people { get; set; }
    }
}
