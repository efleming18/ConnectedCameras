using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectedCamerasWeb.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public string Group { get; set; }
        public string Url { get; set; }

        public Camera()
        {
            Id = 0;
            Name = "";
            Group = "";
            Url = "";
        }
    }
}