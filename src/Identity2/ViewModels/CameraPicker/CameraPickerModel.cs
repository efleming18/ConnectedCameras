using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ConnectedCamerasWeb.Models;

namespace ConnectedCamerasWeb.ViewModels.CameraPicker
{
    public class CameraPickerModel
    {
        public List<Camera> AvailableCameras { get; set; }
        public List<Camera> SelectedCameras { get; set; }
        public PostedCameras PostedCameras { get; set; }
    }
    public class PostedCameras 
    {
        public string[] CameraIDs { get; set; }
    }
}