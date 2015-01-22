using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ConnectedCamerasWeb.ViewModels.CameraPicker;
using ConnectedCamerasWeb.Models;
using ConnectedCamerasWeb.Infrastructure.Data;

namespace ConnectedCamerasWeb.Controllers
{
    public class CameraPickerController : Controller
    {
        [Authorize]
        public ActionResult CameraPicker()
        {
            //TODO: Check for the user's authorization level so this method will only return the cameras in their assigned group.
            var model = new CameraPickerViewModel();
            model.SelectedCameras = new List<Camera>();
            using (var db = new MainDbContext())
            {
                model.AvailableCameras = db.Cameras.ToList();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CameraPicker(PostedCameras postedCameras)
        {
            List<Camera> selectedCameras;
            using (var db = new MainDbContext()) 
            {
                //TODO: Need to do something with the selected cameras so we can get the feed.
                var availableCameras = db.Cameras.ToList();
                selectedCameras = availableCameras.Where(c => postedCameras.CameraIDs.Any(pcId => Convert.ToInt32(pcId) == c.Id)).ToList();
            }
            return RedirectToAction("Cameras");
        }

        [Authorize]
        public ActionResult Cameras()
        {
            return View();
        }

        

    }
}