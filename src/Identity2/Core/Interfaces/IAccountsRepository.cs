using System.Collections.Generic;
using ConnectedCamerasWeb.Core.Model;

namespace ConnectedCamerasWeb.Core.Interfaces
{
    public interface IAccountsRepository
    {
        IEnumerable<Account> GetAllAccounts();
    }
}
