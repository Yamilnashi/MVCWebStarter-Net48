using System.Web.Mvc;

namespace WebMvc.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("OneColumn")]
        public ActionResult OneColumn()
        {
            return View();
        }

        [Route("TwoColumns")]
        public ActionResult TwoColumns()
        {
            return View();
        }

        [Route("ThreeColumns")]
        public ActionResult ThreeColumns()
        {
            return View();
        }
    }
}