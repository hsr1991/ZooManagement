using Microsoft.EntityFrameworkCore;
using Zoo_Management.Models.Database;

namespace Zoo_Management
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) {}
        
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Species> Species {get; set;}
    }

}