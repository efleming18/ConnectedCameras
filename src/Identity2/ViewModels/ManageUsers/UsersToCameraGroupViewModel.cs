using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectedCamerasWeb.Models;

namespace Identity2.ViewModels.ManageUsers
{
    public class UsersToCameraGroupViewModel
    {
        public List<AspNetUser> SelectedUsers { get; set; }
        public IEnumerable<int> CameraGroups { get; set; }
    }
}
