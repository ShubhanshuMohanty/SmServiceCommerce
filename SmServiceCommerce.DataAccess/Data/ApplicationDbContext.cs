using Microsoft.EntityFrameworkCore;
using SmServiceCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Service> services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, ServiceName = "Plumber" },
                new Service { Id = 2, ServiceName = "Electrician" },
                new Service { Id = 3, ServiceName = "Carpenter" }
                );
        }
    }
}
