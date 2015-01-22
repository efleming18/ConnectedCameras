using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConnectedCamerasWeb.Models;
using ConnectedCamerasWeb.Infrastructure.Data;

namespace Identity2.Controllers
{
    public class CreateCameraController : Controller
    {
        // GET: CreateCamera
        public ActionResult CreateCamera()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCamera(Cameras camera)
        {
            var db = new MainDbContext();
            db.Cameras.Add(camera);
            
            return View();
        }
    }
}