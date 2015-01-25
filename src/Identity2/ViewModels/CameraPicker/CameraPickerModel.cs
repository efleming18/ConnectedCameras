using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ConnectedCamerasWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace ConnectedCamerasWeb.ViewModels.CameraPicker
{
    public class CameraPickerViewModel
    {
        public List<Camera> AvailableCameras { get; set; }
        public List<Camera> SelectedCameras { get; set; }
        public PostedCameras PostedCameras { get; set; }
    }
    public class PostedCameras : IValidatableObject
    {
        public int[] CameraIDs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CameraIDs == null)
                yield return new ValidationResult("You must select a camera to continue.");
        }
    }
}