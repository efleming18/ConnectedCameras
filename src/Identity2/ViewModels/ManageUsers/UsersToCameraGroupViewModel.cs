using System.Collections.Generic;
using ConnectedCamerasWeb.Models;

namespace Identity2.ViewModels.ManageUsers
{
    public class UsersToCameraGroupViewModel
    {
        public List<AspNetUser> SelectedUsers { get; set; }
        public IEnumerable<int> CameraGroups { get; set; }
    }
}
