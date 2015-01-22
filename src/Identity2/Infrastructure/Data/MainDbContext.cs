using System.Data.Entity;
using ConnectedCamerasWeb.Core.Model;
using ConnectedCamerasWeb.Models;

namespace ConnectedCamerasWeb.Infrastructure.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public MainDbContext() : base("MainConnection")
        {
        }

        public DbSet<Cameras> Cameras { get; set; }
    }
}