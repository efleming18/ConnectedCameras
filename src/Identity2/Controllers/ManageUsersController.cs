using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Routing;
using ConnectedCamerasWeb.Infrastructure.Data;
using System.Linq;
using System.Web.Mvc;
using ConnectedCamerasWeb.Models;
using Identity2.Models;
using Identity2.ViewModels.ManageUsers;

namespace Identity2.Controllers
{
    public class ManageUsersController : Controller
    {
        private MainDbContext _db = new MainDbContext();
        public ActionResult ManageUsersBulk()
        {
            var userlist = _db.Users.ToList();
            var userModel = new ManageUserModel();
            userModel.AllUsers = userlist;
            userlist[0].CameraGroup = 17;
            _db.SaveChanges();
            return View(userlist);
        }

        [HttpPost]
        public ActionResult ManageUsersBulk(FormCollection formCollection)
        {
            var usersSelected = _db.Users.ToList();
            var selectedUsers = formCollection[1].Split(',');
            var listOfUsersSelected = new List<AspNetUser>();
            foreach (var id in selectedUsers)
            {
                listOfUsersSelected.Add(usersSelected.Single(x => x.Id == id.ToString()));
            }
            
            return AddSelectedUsersToGroup(listOfUsersSelected);
        }

        public ActionResult AddSelectedUsersToGroup()
        {
            var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();

            return View();
        }

        [HttpPost]
        public ActionResult AddSelectedUsersToGroup(List<AspNetUser> usersSelected)
        {
            var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();

            var viewModel = new UsersToCameraGroupViewModel();
            viewModel.CameraGroups = availableCameraGroups;
            viewModel.SelectedUsers = usersSelected;
            return View("AddSelectedUsersToGroup", viewModel);
        }
    }
}