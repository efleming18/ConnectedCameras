using System.Data.Entity;
using ConnectedCamerasWeb.Core.Model;

namespace ConnectedCamerasWeb.Infrastructure.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public MainDbContext() : base("MainConnection")
        {
        }
    }
}