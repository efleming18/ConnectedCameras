using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ConnectedCamerasWeb.Models;

namespace ConnectedCamerasWeb.ViewModels.CameraPicker
{
    public class CameraPickerViewModel
    {
        public List<Cameras> AvailableCameras { get; set; }
        public List<Cameras> SelectedCameras { get; set; }
        public PostedCameras PostedCameras { get; set; }
    }
    public class PostedCameras 
    {
        public string[] CameraIDs { get; set; }
    }
}