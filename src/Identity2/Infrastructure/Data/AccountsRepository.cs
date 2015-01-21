using System.Collections.Generic;
using System.Linq;
using ConnectedCamerasWeb.Core.Interfaces;
using ConnectedCamerasWeb.Core.Model;

namespace ConnectedCamerasWeb.Infrastructure.Data
{
    public class AccountsRepository : IAccountsRepository
    {
        private MainDbContext db = new MainDbContext();

        public virtual IEnumerable<Account> GetAllAccounts()
        {
            return db.Accounts.ToList();
        }
    }
}
