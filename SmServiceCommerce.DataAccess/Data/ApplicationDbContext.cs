using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmServiceCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Service> services { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, ServiceName = "Plumber" },
                new Service { Id = 2, ServiceName = "Electrician" },
                new Service { Id = 3, ServiceName = "Carpenter" }
            );



            modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.ApplicationUserId)
            .OnDelete(DeleteBehavior.Cascade); // ✅ Customer delete → bookings delete

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.ServiceProvider)
                .WithMany()
                .HasForeignKey(b => b.ServiceProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Or keep this as the primary cascade

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ServiceProvider)
                .WithMany()
                .HasForeignKey(r => r.ServiceProviderId)
                .OnDelete(DeleteBehavior.Restrict); // <-- Add this line to fix the conflict

        }
    }
}
