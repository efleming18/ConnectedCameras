using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectedCamerasWeb.Models
{
    [Table("CameraLock")]
    public class CameraLock
    {
        [Key]
        public int Id { get; set; }
        public int CameraId { get; set; }
        public string UserId { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}