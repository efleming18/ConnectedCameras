namespace Identity2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<ConnectedCamerasWeb.Infrastructure.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ConnectedCamerasWeb.Infrastructure.Data.ApplicationDbContext context)
        {
            base.Seed(context);
            context.Roles.AddOrUpdate(
                x => x.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Camera User"}
                );
            context.SaveChanges();
        }
    }
}