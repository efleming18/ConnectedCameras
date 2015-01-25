using System.Data.Entity;
using ConnectedCamerasWeb.Core.Model;

namespace ConnectedCamerasWeb.Infrastructure.Data
{
    public class MainDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            CreateInitialAccounts();
            base.Seed(context);
        }

        private void CreateInitialAccounts()
        {
            //var db = new ApplicationDbContext();
            //db.Accounts.Add(new Account() {Name = "Acme"});
            //db.SaveChanges();
        }
    }
}