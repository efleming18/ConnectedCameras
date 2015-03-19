using System.Collections.Generic;
using System.Web.Security;
using ConnectedCamerasWeb.Infrastructure.Data;
using ConnectedCamerasWeb.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ConnectedCamerasWeb.Controllers
{
    public class CamerasController : Controller
    {
        private MainDbContext _db = new MainDbContext();

        [Authorize]
        public ActionResult Pick()
        {
            var model = new List<Camera>();
            var currentlyLoggedInUser = System.Web.HttpContext.Current.User.Identity.Name;
            var currentUserInDatabase = _db.Users.Single(x => x.UserName == currentlyLoggedInUser);
            var cameraGroupForUser = currentUserInDatabase.CameraGroup;
            if (cameraGroupForUser != null)
            {
                model = _db.Cameras.Where(x => x.CameraGroup == cameraGroupForUser).ToList();   
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add(Camera camera)
        {
            _db.Cameras.Add(camera);
            await _db.SaveChangesAsync();
            return RedirectToAction("Pick");
        }

        [Authorize]
        public ActionResult Remove()
        {
            var model = _db.Cameras.ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Remove(int[] selectedCameraIds) 
        {
            if (selectedCameraIds == null)
                return RedirectToAction("Remove");

            var camerasToRemove = _db.Cameras.Where(dbc => selectedCameraIds.Any(sId => sId == dbc.Id)).ToList();
            _db.Cameras.RemoveRange(camerasToRemove);
            await _db.SaveChangesAsync();

            var model = _db.Cameras.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult LiveFeed(int[] selectedCameraIds, bool allowOtherViewers = false)
        {
            Response.AppendCookie(SetCookie());
            if (!allowOtherViewers)
            {
                foreach (var id in selectedCameraIds)
                    _db.CameraLocks.Add(new CameraLock { CameraId = id, UserId = User.Identity.GetUserId(), TimeStamp = DateTime.UtcNow });
                _db.SaveChanges();
            }
            var cameras = _db.Cameras.Where(dbc => selectedCameraIds.Any(sId => sId == dbc.Id)).ToList();
            return View(cameras);
        }
        private HttpCookie SetCookie() 
        {
            var ticket = new FormsAuthenticationTicket(1, "ticket", DateTime.Now, DateTime.Now.AddMinutes(1), true, FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(ticket);
            return new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath,
                Expires = DateTime.Now.AddMinutes(1),
                Domain = FormsAuthentication.CookieDomain
            };
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}