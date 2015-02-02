using ConnectedCamerasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectedCamerasWeb.ViewModels.Cameras
{
    public class LiveFeedViewModel
    {
        public List<Camera> Cameras { get; set; }

        public string DecideFeedSize() 
        {
            if (Cameras.Count < 2)
                return "large live-feed center";
            else if (Cameras.Count < 5)
                return "medium live-feed center";
            return "small live-feed center";
        }
    }
}