using System;
using System.Collections.Generic;
using ConnectedCamerasWeb.Infrastructure.Data;
using System.Linq;
using System.Web.Mvc;
using ConnectedCamerasWeb.Models;
using ConnectedCamerasWeb.ViewModels.ManageUsers;
using ConnectedCamerasWeb.Attributes;
using System.Threading.Tasks;

namespace ConnectedCamerasWeb.Controllers
{
    public class ManageUsersController : Controller
    {
        private MainDbContext _db = new MainDbContext();

        [Authorize]
        public ActionResult ManageUsersBulk()
        {
            var userlist = _db.Users.ToList();
            return View(userlist);
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Privileges")]
        public ActionResult Privileges(string[] selectedUserIds)
        {
            if (selectedUserIds == null)
                return RedirectToAction("ManageUsersBulk");
            return View();
        }
        [HttpPost]
        public ActionResult Privileges(string[] userIds, int selectedRole)
        {
            return View();
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "AddSelectedUsersToGroup")]
        public ActionResult AddSelectedUsersToGroup(string[] selectedUserIds)
        {
            if (selectedUserIds == null)
                return RedirectToAction("ManageUsersBulk");

            var selectedUsers = _db.Users.Where(dbu => selectedUserIds.Any(sId => sId == dbu.Id)).OrderBy(dbu => dbu.Email).ToList();
            var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();
            return View(new UsersToCameraGroupViewModel() 
            {
                CameraGroups = availableCameraGroups,
                SelectedUsers = selectedUsers
            });
        }
        [HttpPost]
        public async Task<ActionResult> AddSelectedUsersToGroup(string[] userIds, int selectedGroup = 0)
        {
            var selectedUsers = _db.Users.Where(dbu => userIds.Any(sId => sId == dbu.Id)).ToList();
            if (selectedGroup == 0) //Assuming we do not have a group 0
            {
                var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();
                return View(new UsersToCameraGroupViewModel() { CameraGroups = availableCameraGroups, SelectedUsers = selectedUsers });
            }
            foreach (var user in selectedUsers)
            {
                user.CameraGroup = selectedGroup;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("ManageUsersBulk");
        }
        



        //[HttpPost]
        //public ActionResult AddSelectedUsersToGroup(List<AspNetUser> usersSelected, FormCollection formCollection)
        //{
        //    var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();
        //    var viewModel = new UsersToCameraGroupViewModel();

        //    if (formCollection != null)
        //    {
        //        HandleAddingUsersToSpecificCameraGroup(formCollection);
        //        return RedirectToAction("ManageUsersBulk");
        //    }
            
        //    if (usersSelected != null)
        //    {
        //        viewModel.CameraGroups = availableCameraGroups;
        //        viewModel.SelectedUsers = usersSelected;
        //        return View("AddSelectedUsersToGroup", viewModel);
        //    }

        //    return View("AddSelectedUsersToGroup", viewModel);
        //}

        //Pull these private functions out in to a "Helper" or "Manager" class.
        private void HandleAddingUsersToSpecificCameraGroup(FormCollection formCollection)
        {
            var usersActuallySelected = GetActualListOfBooleans(formCollection[0].Split(','));
            var userGuids = formCollection[1].Split(',');
            var actualCamerGroupsSelected = GetActualListOfBooleans(formCollection[2].Split(','));
            var possibleCameraGroups = formCollection[3].Split(',');
            var usersToUpdate = new List<string>();
            var cameraGroupsToAddTo = new List<string>();
            var usersToUpdate1 = new List<AspNetUser>();
            var usersSelected1 = _db.Users.ToList();

            for (int i = 0; i < userGuids.Count(); i++)
            {
                if (usersActuallySelected[i] == "true")
                {
                    usersToUpdate.Add(userGuids[i]);
                }
            }

            foreach (var id in usersToUpdate)
            {
                usersToUpdate1.Add(usersSelected1.Single(x => x.Id == id.ToString()));
            }

            for (int i = 0; i < possibleCameraGroups.Count(); i++)
            {
                if (actualCamerGroupsSelected[i] == "true")
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

        private List<AspNetUser> AddOnlySelectedUsers(string[] selectedUsers, string[] listOfSelectedBooleans, List<AspNetUser> usersSelected)
        {
            var actualListOfBooleans = GetActualListOfBooleans(listOfSelectedBooleans);
            var listOfUsersSelected = new List<AspNetUser>();
            for (int i = 0; i < actualListOfBooleans.Count(); i++)
            {
                if (actualListOfBooleans[i] == "true")
                {
                    listOfUsersSelected.Add(usersSelected.Single(x => x.Id == selectedUsers[i].ToString()));
                }
            }
            return listOfUsersSelected;
        }

        private List<string> GetActualListOfBooleans(string[] listOfSelectedBooleans)
        {
            var listToReturn = new List<string>();
            for (int i = 0; i < listOfSelectedBooleans.Count(); i++)
            {
                listToReturn.Add(listOfSelectedBooleans[i]);
                if (listOfSelectedBooleans[i] == "true")
                {
                    i++;   
                }
            }
            return listToReturn;
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}