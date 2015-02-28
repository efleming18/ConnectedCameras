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
                return "big-feed";
            else if (Cameras.Count < 5)
                return "medium-feed";
            return "small-feed";
        }
        //We could turn this into an Html helper maybe...
        public IHtmlString GenerateFeedHtml()
        {
            string htmlString;
            switch (Cameras.Count)
            {
                case 1:
                    htmlString = string.Format("<div id='{0}' class='row100percent'>" + 
                                                   "<img class='fill center' src='../../Content/Images/cat.gif' />" + 
                                               "</div>",
                                                Cameras[0].CameraName);
                    break;
                case 2:
                    htmlString = string.Format("<div id='{0}' class='row50percent'>" + 
                                                   "<img class='fill center' src='../../Content/Images/cat.gif' />" + 
                                               "</div>" + 
                                               "<div id='{1}' class='row50percent'>" + 
                                                    "<img class='fill center' src='../../Content/Images/cat.gif' />" + 
                                                "</div>",
                                                Cameras[0].CameraName,
                                                Cameras[1].CameraName);
                    break;
                case 3:
                    htmlString = "";
                    break;
                case 4:
                    htmlString = "";
                    break;
                case 5:
                    htmlString = "";
                    break;
                case 6:
                    htmlString = "";
                    break;
                default:
                    htmlString = "We do not support this many cameras.";
                    break;
            }
            return new HtmlString(htmlString);
        }
    }
}