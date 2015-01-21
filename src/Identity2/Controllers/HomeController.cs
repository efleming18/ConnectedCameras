using System.Web.Mvc;

namespace ConnectedCamerasWeb.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What is Connected Cameras About?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact us at..";

            return View();
        }
    }
}