using Microsoft.EntityFrameworkCore;
using Restaurant_manager_x_backend.Models;

namespace Restaurant_manager_x_backend.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(u => u.id);
            modelBuilder.Entity<Dish>().HasKey(d => d.id);
        }
    }

    
}