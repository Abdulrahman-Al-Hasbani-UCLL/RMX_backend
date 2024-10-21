using Microsoft.EntityFrameworkCore;
using Restaurant_manager_x_backend.Models;

namespace Restaurant_manager_x_backend.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Dish> Dishes { get; set; }
    }
}