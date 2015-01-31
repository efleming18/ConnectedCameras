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
                return "large-feed";
            else if (Cameras.Count < 5)
                return "medium-feed";
            return "small-feed";
        }
    }
}