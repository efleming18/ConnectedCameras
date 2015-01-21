using System.Collections.Generic;

namespace ConnectedCamerasWeb.Core.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityUserId { get; set; }

        IList<Account> AccountsManaged { get; set; }

        public User()
        {
            AccountsManaged = new List<Account>();
        }
    }
}