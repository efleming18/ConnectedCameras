using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConnectedCamerasWeb.Models;
using ConnectedCamerasWeb.Infrastructure.Data;
using System.Threading.Tasks;

namespace ConnectedCamerasWeb.Controllers
{
    public class CreateCameraController : Controller
    {
        public ActionResult CreateCamera()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCamera(Cameras camera)
        {
            using (var db = new MainDbContext())
            {
                db.Cameras.Add(camera);
                await db.SaveChangesAsync();
            }
            return View();
        }
    }
}