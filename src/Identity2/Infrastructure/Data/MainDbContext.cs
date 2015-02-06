using System.Data.Entity;
using ConnectedCamerasWeb.Core.Model;
using ConnectedCamerasWeb.Models;

namespace ConnectedCamerasWeb.Infrastructure.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public MainDbContext() : base("MainConnection")
        {
        }

        public DbSet<Camera> Cameras { get; set; }
        public DbSet<AspNetRole> DefinedRoles { get; set; }
        public DbSet<AspNetUserRole> UserRoles { get; set; }
        public DbSet<AspNetUser> Users { get; set; }
    }
}