﻿using System;
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
                listOfUsersSelected = AddOnlySelectedUsers(selectedUsers, listOfSelectedBooleans, usersSelected);
            }
            
            return AddSelectedUsersToGroup(listOfUsersSelected, null);
        }
        
        //Desperately need to refactor this code
        [HttpPost]
        public ActionResult AddSelectedUsersToGroup(List<AspNetUser> usersSelected, FormCollection formCollection)
        {
            var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();
            var viewModel = new UsersToCameraGroupViewModel();

            if (formCollection != null)
            {
                HandleAddingUsersToSpecificCameraGroup(formCollection);
            }
            
            if (usersSelected != null)
            {
                viewModel.CameraGroups = availableCameraGroups;
                viewModel.SelectedUsers = usersSelected;
                return View("AddSelectedUsersToGroup", viewModel);
            }

            return View("AddSelectedUsersToGroup", viewModel);
        }

        //Possibly pull these private functions out in to a "Helper" or "Manager" class.
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
    }
}