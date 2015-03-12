using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConnectedCamerasWeb.Models;

namespace ConnectedCamerasWeb.ViewModels.Cameras
{
    public class LiveFeedViewModel
    {
        public List<Camera> Cameras { get; set; }
        public bool AllowOtherViewers { get; set; }
    }
}