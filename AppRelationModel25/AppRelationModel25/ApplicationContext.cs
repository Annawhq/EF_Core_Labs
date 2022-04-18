using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppRelationModel25
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;" +
            "Port=5432;" +
            "Database=testdb1;" +
            "Username=postgres;" +
            "Password=1234");
        }
    }
}
