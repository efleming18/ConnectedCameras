using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConnectedCamerasWeb.Models;

namespace ConnectedCamerasWeb.ViewModels.ManageUsers
{
    public class UserPrivilegesViewModel
    {
        public IEnumerable<AspNetUser> Users { get; set; }
        public IEnumerable<AspNetRole> Definedroles { get; set; }
    }
}