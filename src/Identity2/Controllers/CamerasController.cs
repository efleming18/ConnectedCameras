using System.Web.Security;
using ConnectedCamerasWeb.Infrastructure.Data;
using ConnectedCamerasWeb.Models;
using ConnectedCamerasWeb.ViewModels.Cameras;
using ConnectedCamerasWeb.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConnectedCamerasWeb.Controllers
{
    public class CamerasController : Controller
    {
        private MainDbContext _db = new MainDbContext();

        [Authorize]
        public ActionResult Pick()
        {
            var model = new CameraPickerViewModel();
            model.SelectedCameras = new List<Camera>();
            model.AvailableCameras = _db.Cameras.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Pick(int[] selectedCameraIds)
        {
            if (selectedCameraIds == null)
                return RedirectToAction("Pick");
            TempData["selectedCameraIds"] = selectedCameraIds;
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
            var model = new CameraPickerViewModel();
            model.SelectedCameras = new List<Camera>();
            model.AvailableCameras = _db.Cameras.ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Remove(PostedCameras postedCameras) 
        {
            if (postedCameras.CameraIDs == null)
                return RedirectToAction("Remove");

            var camerasToRemove = _db.Cameras.Where(dbc => postedCameras.CameraIDs.Any(sId => sId == dbc.Id)).ToList();
            _db.Cameras.RemoveRange(camerasToRemove);
            await _db.SaveChangesAsync();

            var model = new CameraPickerViewModel();
            model.SelectedCameras = new List<Camera>();
            model.AvailableCameras = _db.Cameras.ToList();
            return View(model);
        } 

        [Authorize]
        public ActionResult LiveFeed(string id = "1")
        {
            var ticket = new FormsAuthenticationTicket(1, "ticket", DateTime.Now, DateTime.Now.AddMinutes(1), true, FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath,
                Expires = DateTime.Now.AddMinutes(1),
                Domain = FormsAuthentication.CookieDomain
            };
            Response.AppendCookie(cookie);
            int[] cameraIds = TempData["selectedCameraIds"] as int[];
            var cameras = _db.Cameras.Where(dbc => cameraIds.Any(sId => sId == dbc.Id)).ToList();
            return View(cameras);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}