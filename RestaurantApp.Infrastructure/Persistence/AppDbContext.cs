using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().ToTable("Restaurants");
            modelBuilder.Entity<Restaurant>().HasKey(r => r.Id);
            modelBuilder.Entity<Restaurant>().Property(r => r.Nom).IsRequired();
            modelBuilder.Entity<Restaurant>().Property(r => r.Adresse).IsRequired();
            modelBuilder.Entity<Restaurant>().Property(r => r.Cuisine).IsRequired();
            modelBuilder.Entity<Restaurant>().Property(r => r.Note).HasDefaultValue(0);
            modelBuilder.Entity<Restaurant>().Property(r => r.ImagePath).IsRequired(false);
        }
    }
}
