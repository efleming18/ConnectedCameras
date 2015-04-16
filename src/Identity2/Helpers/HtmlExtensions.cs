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
        public static IHtmlString LiveFeedForFireFox(this HtmlHelper helper, List<Camera> cameras)
        {
            string htmlString = "";
            switch (cameras.Count)
            {
                case 1:
                    htmlString = string.Format("<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{0}' style='z-index:5;'></embed>",
                                   cameras[0].CameraUrl);
                    break;
                case 2:
                    htmlString = string.Format("<div class='row50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{0}' style='z-index:5;'></embed>" +
                                 "</div>" +
                                 "<div class='row50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{2}' style='z-index:5;'></embed>" +
                                 "</div>", cameras[0].CameraUrl,
                                           cameras[1].CameraUrl);
                    break;
                case 3:
                    htmlString = string.Format("<div class='row50percent'>" +
                                    "<div class='cell50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{0}' style='z-index:5;'></embed>" +
                                    "</div>" +
                                    "<div class='cell50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{1}' style='z-index:5;'></embed>" +
                                    "</div>" +
                                 "</div>" +
                                 "<div class='row50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{2}' style='z-index:5;'></embed>" +
                                 "</div>", cameras[0].CameraUrl,
                                           cameras[1].CameraUrl,
                                           cameras[2].CameraUrl);
                    break;
                case 4:
                    htmlString = string.Format("<div class='row50percent'>" + 
                                    "<div class='cell50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{0}' style='z-index:5;'></embed>" + 
                                    "</div>" + 
                                    "<div class='cell50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{1}' style='z-index:5;'></embed>" + 
                                    "</div>" + 
                                 "</div>" + 
                                 "<div class='row50percent'>" + 
                                    "<div class='cell50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{2}' style='z-index:5;'></embed>" + 
                                    "</div>" + 
                                    "<div class='cell50percent'>" +
                                        "<embed type='application/x-vlc-plugin' text='This stream cannot be accessed at this time...' controls='false' name='VLC' autoplay='yes' loop='no' volume='100' width='100%' height='100%' target='{3}' style='z-index:5;'></embed>" + 
                                    "</div>" + 
                                 "</div>", cameras[0].CameraUrl, 
                                           cameras[1].CameraUrl,
                                           cameras[2].CameraUrl,
                                           cameras[3].CameraUrl);
                    break;
            }
            return new HtmlString(htmlString);
        }
    }
}