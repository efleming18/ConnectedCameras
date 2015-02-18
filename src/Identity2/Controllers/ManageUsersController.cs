using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Routing;
using ConnectedCamerasWeb.Infrastructure.Data;
using System.Linq;
using System.Web.Mvc;
using ConnectedCamerasWeb.Models;
using Identity2.Models;

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
        [Route("ManageUsers/ManageUsersBulk")]
        public ActionResult ManageUsersBulk(Guid[] ids)
        {
            var usersSelected = _db.Users.ToList();
            var listOfUsersSelected = new List<AspNetUser>();
            foreach (var id in ids)
            {
                listOfUsersSelected.Add(usersSelected.Single(x => x.Id == id.ToString()));
            }
            
            return View(listOfUsersSelected);
        }

        //[HttpPost]
        //[Route("ManageUsers/AddSelectedUsersToGroup")]
        //public ActionResult AddSelectedUsersToGroup(Guid[] usersSelected)
        //{
        //    var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();

        //    return View();
        //}

        public ActionResult AddSelectedUsersToGroup()
        {
            var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();

            return View();
        }
        [HttpPost]
        [Route("ManageUsers/AddSelectedUsersToGroup")]
        public ActionResult AddSelectedUsersToGroup(Guid[] usersSelected)
        {
            var availableCameraGroups = _db.Cameras.ToList().Select(x => x.CameraGroup).Distinct();

            return View("AddSelectedUsersToGroup");
        }
    }
}