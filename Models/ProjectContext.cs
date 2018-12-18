using Microsoft.EntityFrameworkCore;

namespace chefsdishes.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) {}
        public  DbSet<Dish> Dishes { get; set;}
        public  DbSet<Chef> Chefs { get; set;}
    }
}