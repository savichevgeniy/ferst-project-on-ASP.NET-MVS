using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvroValExport.Models
{
    public class UserContext : DbContext
    {
        public UserContext():
            base("DefaultConnection")
            { }
            public DbSet<User> Users { get; set; }
            public DbSet<Workers> Workers { get; set; }
            public DbSet<Lining > Linings { get; set; }
            public DbSet<Plinth> Plinths { get; set; }
            public DbSet<OtherProducts> OtherProducts { get; set; }
            public DbSet<News> News { get; set; }
    }
}