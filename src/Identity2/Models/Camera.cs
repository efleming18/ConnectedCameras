using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectedCamerasWeb.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string CameraName { get; set; }
        public int CameraGroup { get; set; }
        public string CameraUrl { get; set; }
    }
}