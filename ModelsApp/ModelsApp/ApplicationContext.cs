using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApp
{
    public class ApplicationContext : DbContext
 {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=efbasicsappdb; Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(u => u.Id);
            modelBuilder.Entity<Company>().HasData(
            new Company[]
            {
                new Company { Id=1, Name="Microsoft"},
                new Company { Id=2, Name="Apple"},
                new Company { Id=3, Name="Google"}
            });
        }
    }
}
