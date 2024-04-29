using Microsoft.EntityFrameworkCore;
using task.Models;

namespace task.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Emp> Emp { get; set; }
        public DbSet<LoginViewModel>Logins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }

}
