using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectedCamerasWeb.Models
{
    public class Cameras
    {
        public int Id { get; set; }
        public string CameraName { get; set; }
        public string CameraGroup { get; set; }
        public string CameraUrl { get; set; }
    }
}