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
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}