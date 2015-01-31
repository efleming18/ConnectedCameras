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
        public ActionResult Pick(PostedCameras postedCameras)
        {
            if (postedCameras.CameraIDs == null)
                return RedirectToAction("Pick");
            
            return RedirectToAction("LiveFeed", "Cameras", new { id = postedCameras.CameraIDs.Stringify() });
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
        public ActionResult LiveFeed(string id = "1")
        {
            int[] cameraIds = id.UnStringify();
            var liveFeedViewModel = new LiveFeedViewModel();
            liveFeedViewModel.Cameras = _db.Cameras.Where(dbc => cameraIds.Any(sId => sId == dbc.Id)).ToList();
            return View(liveFeedViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}