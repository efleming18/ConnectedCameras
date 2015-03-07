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
                                                   "<div class='feed center-vertical'>" +
                                                       "<div class='feed-content'>" +
                                                            "<img id='{0}' class='fill' src='{1}' />" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>",
                                                cameras[0].CameraName,
                                                cameras[0].CameraUrl);
                    break;
                case 2:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" +
                                                   "<img id='{0}' class='fill center-vertical' src='{1}' />" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<img id='{2}' class='fill center-vertical' src='{3}' />" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[0].CameraUrl,
                                               cameras[1].CameraName,
                                               cameras[1].CameraUrl);
                    break;
                case 3:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{0}' class='fill' src='{1}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{2}' class='fill' src='{3}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<img id='{4}' class='fill center' src='{5}' />" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[0].CameraUrl,
                                               cameras[1].CameraName,
                                               cameras[1].CameraUrl,
                                               cameras[2].CameraName,
                                               cameras[2].CameraUrl);
                    break;
                case 4:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{0}' class='fill' src='{1}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{2}' class='fill' src='{3}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{4}' class='fill' src='{5}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" + 
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{6}' class='fill' src='{7}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[0].CameraUrl,
                                               cameras[1].CameraName,
                                               cameras[1].CameraUrl,
                                               cameras[2].CameraName,
                                               cameras[2].CameraUrl,
                                               cameras[3].CameraName,
                                               cameras[3].CameraUrl);
                    break;
                case 5:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{0}' class='fill' src='{1}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{2}' class='fill' src='{3}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{4}' class='fill' src='{5}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{6}' class='fill' src='{7}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{8}' class='fill' src='{9}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[0].CameraUrl,
                                               cameras[1].CameraName,
                                               cameras[1].CameraUrl,
                                               cameras[2].CameraName,
                                               cameras[2].CameraUrl,
                                               cameras[3].CameraName,
                                               cameras[3].CameraUrl,
                                               cameras[4].CameraName,
                                               cameras[4].CameraUrl);
                    break;
                case 6:
                    htmlString = string.Format("<div class='row50percent' style='background-color:black;'>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{0}' class='fill' src='{1}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" + 
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{2}' class='fill' src='{3}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{4}' class='fill' src='{5}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{6}' class='fill' src='{7}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{8}' class='fill' src='{9}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               "<img id='{10}' class='fill' src='{11}' />" +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>",
                                               cameras[0].CameraName,
                                               cameras[0].CameraUrl,
                                               cameras[1].CameraName,
                                               cameras[1].CameraUrl,
                                               cameras[2].CameraName,
                                               cameras[2].CameraUrl,
                                               cameras[3].CameraName,
                                               cameras[3].CameraUrl,
                                               cameras[4].CameraName,
                                               cameras[4].CameraUrl,
                                               cameras[5].CameraName,
                                               cameras[5].CameraUrl);
                    break;
                default:
                    htmlString = "We do not support this many cameras.";
                    break;
            }
            return new HtmlString(htmlString);
        }
    }
}