using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConnectedCamerasWeb.Models;
using System.Web.Mvc;

namespace ConnectedCamerasWeb.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlString LiveFeedFor(this HtmlHelper helper, List<Camera> cameras)
        {
            string htmlString;
            switch (cameras.Count)
            {
                case 1:
                    htmlString = string.Format("<div class='row100percent' style='background-color:black;'>" +
                                                   "<img id='{0}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                               "</div>",
                                                cameras[0].CameraName);
                    break;
                case 2:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" +
                                                   "<img id='{0}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                               "</div>" +
                                               "<div class='row50percent'>" +
                                                    "<img id='{1}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                "</div>",
                                                cameras[0].CameraName,
                                                cameras[1].CameraName);
                    break;
                case 3:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{0}' class='fill center' src='../../Content/Images/cat.gif' />" + 
                                                   "</div>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{1}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<img id='{2}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[1].CameraName,
                                               cameras[2].CameraName);
                    break;
                case 4:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{0}' class='fill center' src='../../Content/Images/cat.gif' />" + 
                                                   "</div>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{1}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{2}' class='fill center' src='../../Content/Images/cat.gif' />" + 
                                                   "</div>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{3}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[1].CameraName,
                                               cameras[2].CameraName,
                                               cameras[3].CameraName);
                    break;
                case 5:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{0}' class='fill center' src='../../Content/Images/cat.gif' />" + 
                                                   "</div>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{1}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{2}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{3}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                                   "<div class='cell50percent'>" +
                                                       "<img id='{4}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[1].CameraName,
                                               cameras[2].CameraName,
                                               cameras[3].CameraName,
                                               cameras[4].CameraName);
                    break;
                case 6:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{0}' class='fill center' src='../../Content/Images/cat.gif' />" + 
                                                   "</div>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{1}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{2}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{3}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{4}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<img id='{5}' class='fill center' src='../../Content/Images/cat.gif' />" +
                                                   "</div>" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[1].CameraName,
                                               cameras[2].CameraName,
                                               cameras[3].CameraName,
                                               cameras[4].CameraName,
                                               cameras[5].CameraName);
                    break;
                default:
                    htmlString = "We do not support this many cameras.";
                    break;
            }
            return new HtmlString(htmlString);
        }
    }
}