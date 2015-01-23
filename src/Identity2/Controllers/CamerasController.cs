using ConnectedCamerasWeb.Infrastructure.Data;
using ConnectedCamerasWeb.Models;
using ConnectedCamerasWeb.ViewModels.CameraPicker;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Pick(PostedCameras postedCameras)
        {
            List<Camera> selectedCameras;
            var availableCameras = _db.Cameras.ToList();
            selectedCameras = availableCameras.Where(c => postedCameras.CameraIDs.Any(pcId => Convert.ToInt32(pcId) == c.Id)).ToList();
            return RedirectToAction("LiveFeed");
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Camera camera)
        {
            _db.Cameras.Add(camera);
            _db.SaveChanges();
            return View();
        }

        [Authorize]
        public ActionResult LiveFeed()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}