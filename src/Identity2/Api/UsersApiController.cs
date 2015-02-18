using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ConnectedCamerasWeb.Infrastructure.Data;

namespace Identity2.Api
{
    public class UsersApiController : ApiController
    {
        private MainDbContext _db = new MainDbContext();
        [HttpGet]
        public List<int> GetCameraGroups()
        {
            var cameras = _db.Cameras.ToList();
            var listOfCameraGroups = new List<int>();
            foreach (var camera in cameras)
            {
                listOfCameraGroups.Add(camera.CameraGroup);
            }
            return listOfCameraGroups;
        }
    }
}
