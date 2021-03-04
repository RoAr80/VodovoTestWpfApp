using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public class VodovozClientDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<Order> Orders{ get; set; }

        public VodovozClientDbContext(DbContextOptions<VodovozClientDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>().HasAlternateKey(c => new { c.Number });
            modelBuilder.Entity<Order>().Property(p => p.Number).ValueGeneratedOnAdd();

            modelBuilder.Entity<Subdivision>()
                .HasMany(s => s.Employees)
                .WithOne(e => e.Subdivision);            

            modelBuilder.Entity<Employee>()
                .HasMany(s => s.Orders)
                .WithOne(e => e.Author);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Sex)
                .HasConversion(v => v.ToString(), v => (SexEnum)Enum.Parse(typeof(SexEnum), v));


        }
    }
}
