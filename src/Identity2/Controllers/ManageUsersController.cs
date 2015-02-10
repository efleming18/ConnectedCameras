using ConnectedCamerasWeb.Infrastructure.Data;
using ConnectedCamerasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity2.Controllers
{
    public class ManageUsersController : Controller
    {
        public ActionResult ManageUsersBulk()
        {
            MainDbContext _db = new MainDbContext();
            var userlist = _db.Users.ToList();

            return View(userlist);
        }
        
    }
}