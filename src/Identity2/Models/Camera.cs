using System.ComponentModel.DataAnnotations;

namespace ConnectedCamerasWeb.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string CameraName { get; set; }

        [Range(1,99)]
        public int CameraGroup { get; set; }
        public string CameraUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}