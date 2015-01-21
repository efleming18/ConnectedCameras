using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ConnectedCamerasWeb.ViewModels.CameraPicker;
using ConnectedCamerasWeb.Models;

namespace ConnectedCamerasWeb.Controllers
{
    public class CameraPickerController : Controller
    {
        // GET: CameraPicker
        [Authorize]
        public ActionResult CameraPicker()
        {
            return View(GetAvailableCameras());
        }

        [HttpPost]
        public ActionResult CameraPicker(PostedCameras postedCameras)
        {
            var selectedCameras = _cameras.Where(c => postedCameras.CameraIDs.Any(pcId => Convert.ToInt32(pcId) == c.Id));
            return RedirectToAction("Cameras"); //pass selectedCameras into this?
        }
        public ActionResult Cameras()
        {
            //TODO: Make the magic happen where we get the live video stream.
            return View();
        }

        //TODO: Check for the user's authorization level so this method will only return the cameras in their assigned group.
        private CameraPickerModel GetAvailableCameras()
        {
            var model = new CameraPickerModel();
            model.SelectedCameras = new List<Camera>();
            model.AvailableCameras = _cameras; //Fetch from database.
            return model;
        }

        //TODO: Delete this and fetch this data from the database
        private static List<Camera> _cameras = new List<Camera>
        {
            new Camera { Name = "Family Room", Id = 1 },
            new Camera { Name = "Kitchen", Id = 2 },
            new Camera { Name = "Basement", Id = 3 },
            new Camera { Name = "Foyer", Id = 4 },
        };

    }
}