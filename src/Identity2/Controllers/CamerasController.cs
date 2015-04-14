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
using ConnectedCamerasWeb.Peripherals;

namespace ConnectedCamerasWeb.Controllers
{
    public class CamerasController : Controller
    {
        private MainDbContext _db;
        private int _timeLockInMinutes;
        private CameraLocker _cameraLocker;

        public CamerasController() 
        {
            _timeLockInMinutes = 15;
            _db = new MainDbContext();
            _cameraLocker = new CameraLocker(_timeLockInMinutes);
        }

        [Authorize]
        public ActionResult Pick()
        {
            var model = new List<Camera>();
            var cameraGroupForUser = GetCameraGroupForLoggedInUser();
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
        public async Task<ActionResult> LiveFeed(int[] selectedCameraIds, bool allowOtherViewers = false)
        {
            if (selectedCameraIds == null)
                RedirectToAction("Pick");

            Response.AppendCookie(SetCookie());

            if (_cameraLocker.AnyLockedCameras(selectedCameraIds, User.Identity.GetUserId()))
                return RedirectToAction("LiveFeedError");

            if (!allowOtherViewers)
                await _cameraLocker.LockAsync(selectedCameraIds, User.Identity.GetUserId());

            return View(_db.Cameras.Where(dbc => selectedCameraIds.Any(sId => sId == dbc.Id)).ToList());
        }
        [Authorize]
        public ActionResult LiveFeedError()
        {
            var lockedCameras = _cameraLocker.LockedCameras;
            return View(lockedCameras);
        }
        public ActionResult GetRemainingTime(int[] cameraIds) 
        {
            var lockedTimeStamp = _cameraLocker.GetTimeStamp(cameraIds);
            var timePassedSinceCameraWasLocked = DateTime.UtcNow - lockedTimeStamp;
            var expirationTimeSpan = TimeSpan.FromMinutes(_timeLockInMinutes);
            var timeRemaining = expirationTimeSpan - timePassedSinceCameraWasLocked; 
            return Json(timeRemaining.Value.TotalMinutes);
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
        private int? GetCameraGroupForLoggedInUser()
        {
            var currentlyLoggedInUser = System.Web.HttpContext.Current.User.Identity.Name;
            var currentUserInDatabase = _db.Users.Single(x => x.UserName == currentlyLoggedInUser);
            var cameraGroupForUser = currentUserInDatabase.CameraGroup;
            return cameraGroupForUser;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            _cameraLocker.Dispose();
            base.Dispose(disposing);
        }
    }
}