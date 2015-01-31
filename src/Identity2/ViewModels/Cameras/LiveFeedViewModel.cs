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
            if (Cameras.Count == 1)
                return "large-feed";
            if (Cameras.Count >= 2 && Cameras.Count <= 4)
                return "medium-feed";
            if (Cameras.Count > 4)
                return "small-feed";
            return "";
        }
    }
}