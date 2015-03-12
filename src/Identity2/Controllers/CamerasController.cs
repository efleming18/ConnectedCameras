using System.Web.Security;
using ConnectedCamerasWeb.Infrastructure.Data;
using ConnectedCamerasWeb.Models;
using System;
using System.Collections.Generic;
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
            var model = _db.Cameras.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Pick(int[] selectedCameraIds, bool allowOtherViewers = false)
        {
            if (selectedCameraIds == null)
                return RedirectToAction("Pick");
            TempData["selectedCameraIds"] = selectedCameraIds;
            TempData["allowOtherViewers"] = allowOtherViewers;
            return RedirectToAction("LiveFeed");
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

        [Authorize]
        public ActionResult LiveFeed()
        {
            Response.AppendCookie(SetCookie());

            int[] cameraIds = TempData["selectedCameraIds"] as int[];
            if (!Convert.ToBoolean(TempData["allowOtherViewers"])) 
            {
                foreach (var id in cameraIds)
                    _db.CameraLocks.Add(new CameraLock { CameraId = id, UserId = User.Identity.GetUserId(), TimeStamp = DateTime.UtcNow});
                _db.SaveChanges();
            }

            var cameras = _db.Cameras.Where(dbc => cameraIds.Any(sId => sId == dbc.Id)).ToList();
            TempData["selectedCameraIds"] = cameraIds; //For the sake of refreshing the screen
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