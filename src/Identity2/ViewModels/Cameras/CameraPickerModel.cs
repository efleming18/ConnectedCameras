using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ConnectedCamerasWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ConnectedCamerasWeb.ViewModels.Cameras
{
    public class CameraPickerViewModel
    {
        public List<Camera> AvailableCameras { get; set; }
        public List<Camera> SelectedCameras { get; set; }
        public PostedCameras PostedCameras { get; set; }
    }
    public class PostedCameras
    {
        public int[] CameraIDs { get; set; }
    }
}