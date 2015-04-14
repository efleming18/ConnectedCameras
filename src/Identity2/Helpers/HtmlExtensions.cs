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
        public static IHtmlString LiveFeed(this HtmlHelper helper, List<Camera> cameras)
        {
            string htmlString;
            switch (cameras.Count)
            {
                case 1:
                    htmlString = "<div class='row100percent' style='background-color:black;'>" +
                                     "<div class='feed center-vertical'>" +
                                         "<div class='feed-content'>" +
                                              EmbedPlayer(cameras[0].CameraUrl, cameras[0].CameraName) +
                                         "</div>" +
                                     "</div>" +
                                 "</div>";
                    break;
                case 2:
                    htmlString = "<div class='row50percent' style='background-color:black;'>" +
                                                   EmbedPlayer(cameras[0].CameraUrl, cameras[0].CameraName) +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   EmbedPlayer(cameras[1].CameraUrl, cameras[1].CameraName) +
                                               "</div>";
                    break;
                case 3:
                    htmlString = "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[0].CameraUrl, cameras[0].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[1].CameraUrl, cameras[1].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   EmbedPlayer(cameras[2].CameraUrl, cameras[2].CameraName) +
                                               "</div>";
                    break;
                case 4:
                    htmlString = "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[0].CameraUrl, cameras[0].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[1].CameraUrl, cameras[1].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[2].CameraUrl, cameras[2].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[3].CameraUrl, cameras[3].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>";
                    break;
                case 5:
                    htmlString = "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[0].CameraUrl, cameras[0].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[1].CameraUrl, cameras[1].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[2].CameraUrl, cameras[2].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[3].CameraUrl, cameras[3].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell50percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[4].CameraUrl, cameras[4].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>";
                    break;
                case 6:
                    htmlString = "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[0].CameraUrl, cameras[0].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[1].CameraUrl, cameras[1].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[2].CameraUrl, cameras[2].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>" +
                                               "<div class='row50percent' style='background-color:black;'>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[3].CameraUrl, cameras[3].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[4].CameraUrl, cameras[4].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                                   "<div class='cell33percent'>" +
                                                       "<div class='feed center-vertical'>" +
                                                           "<div class='feed-content'>" +
                                                               EmbedPlayer(cameras[5].CameraUrl, cameras[5].CameraName) +
                                                           "</div>" +
                                                       "</div>" +
                                                   "</div>" +
                                               "</div>";
                    break;
                default:
                    htmlString = "We do not support this many cameras.";
                    break;
            }
            return new HtmlString(htmlString);
        }
        public static string EmbedPlayer(string sourceUrl, string name)
        {
            var htmlString = string.Format("<OBJECT id='mediaPlayer1' width='180' height='50' classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701' standby='Loading Microsoft Windows Media Player components...' type='application/x-oleobject'>"
                                            + "<param name='fileName' value='{0}'>"
                                            + "<param name='animationatStart' value='true'>"
                                            + "<param name='transparentatStart' value='true'>"
                                            + "<param name='autoStart' value='false'>"
                                            + "<param name='showControls' value='false'>"
                                            + "<param name='ShowAudioControls' value='false'>"
                                            + "<param name='ShowStatusBar' value='false'>"
                                            + "<param name='loop' value='false'>"
                                            + "<EMBED type='application/x-mplayer2' pluginspage='http://microsoft.com/windows/mediaplayer/en/download/' id='{1}' name='mediaPlayer' displaysize='4' autosize='-1' bgcolor='darkblue' showcontrols='true' showtracker='-1'  showdisplay='0' showstatusbar='-1' videoborder3d='-1' width='100%' height='100%' src='{0}' autostart='true' designtimesp='5311' loop='false'></EMBED>"
                                          +"</OBJECT>", sourceUrl, name);
            return htmlString;
        }
    }
}