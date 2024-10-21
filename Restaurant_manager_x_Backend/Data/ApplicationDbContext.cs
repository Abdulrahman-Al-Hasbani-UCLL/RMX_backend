using Microsoft.EntityFrameworkCore;
using Restaurant_manager_x_backend.Models;

namespace Restaurant_manager_x_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
    }
}