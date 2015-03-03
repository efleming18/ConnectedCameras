using System;
using System.Collections.Generic;
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
            if (formCollection != null)
            {
                var listOfSelectedBooleans = formCollection[0].Split(',');
                listOfUsersSelected = AddOnlySelectedUsers(selectedUsers, listOfSelectedBooleans, usersSelected,
                    selectedUsers);
            }
            
            return AddSelectedUsersToGroup(listOfUsersSelected, null);
        }
        
        [HttpPost]
        public ActionResult AddSelectedUsersToGroup(List<AspNetUser> usersSelected, FormCollection formCollection)
        {
            if (formCollection != null)
            {
                var usersActuallySelected = formCollection[0].Split(',');
                var userGuids = formCollection[1].Split(',');
                var cameraGroupActuallySelected = formCollection[2].Split(',');
                var possibleCameraGroups = formCollection[3].Split(',');
                var usersToUpdate = new List<string>();
                var cameraGroupsToAddTo = new List<string>();

                for (int i = 0; i < userGuids.Count(); i++)
                {
                    if (usersActuallySelected[i] == "true")
                    {
                        usersToUpdate.Add(userGuids[i]);
                    }
                }

                var usersToUpdate1 = new List<AspNetUser>();
                var usersSelected1 = _db.Users.ToList();
                foreach (var id in usersToUpdate)
                {
                    usersToUpdate1.Add(usersSelected1.Single(x => x.Id == id.ToString()));
                }

                for (int i = 0; i < possibleCameraGroups.Count(); i++)
                {
                    if (cameraGroupActuallySelected[i] == "true")
                    {
                        cameraGroupsToAddTo.Add(possibleCameraGroups[i]);
                    }
                }
                foreach (var user in usersToUpdate1)
                {
                    user.CameraGroup = Convert.ToInt32(cameraGroupsToAddTo[0]);
                    _db.SaveChanges();
                }
            }
            
            var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();
            var viewModel = new UsersToCameraGroupViewModel();
            var temp = new List<AspNetUser>();
            if (usersSelected != null)
            {
                temp = usersSelected;
            }
            if (usersSelected != null)
            {
                viewModel.CameraGroups = availableCameraGroups;
                viewModel.SelectedUsers = usersSelected;
                return View("AddSelectedUsersToGroup", viewModel);
            }

            if (formCollection != null)
            {
                var results = HandleFormCollection(temp, formCollection);
            }



            return View("AddSelectedUsersToGroup", viewModel);
        }

        //Possibly pull these private functions out in to a "Helper" or "Manager" class.
        private List<AspNetUser> AddOnlySelectedUsers(string[] selectedUsers, string[] listOfSelectedBooleans, List<AspNetUser> usersSelected, string[] strings)
        {
            var listOfUsersSelected = new List<AspNetUser>();
            for (int i = 0; i < listOfSelectedBooleans.Count(); i++)
            {
                if (listOfSelectedBooleans[i] == "true")
                {
                    listOfUsersSelected.Add(usersSelected.Single(x => x.Id == selectedUsers[i].ToString()));
                }
            }
            return listOfUsersSelected;
        }

        private object HandleFormCollection(List<AspNetUser> users, FormCollection formCollection)
        {
            var selectedCameraGroup = formCollection[1].Split(',');
            return null;
        }
    }
}