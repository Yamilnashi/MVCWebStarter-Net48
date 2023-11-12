using System.Web.Mvc;

namespace WebMvc.Controllers
{
    [RoutePrefix("Error")]
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("NotFound")]
        public ActionResult NotFound(string requestedUrl)
        {
            Response.StatusCode = 404;
            ViewBag.RequestedUrl = requestedUrl;
            return View();
        }

        [HttpGet]
        [Route("InternalServer")]
        public ActionResult InternalServer(string errorMessage)
        {            
            Response.StatusCode = 500;
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

        [HttpGet]
        [Route("Forbidden")]
        public ActionResult Forbidden()
        {
            Response.StatusCode = 401;
            return View();
        }

        [HttpGet]
        [Route("Unauthorized")]
        public ActionResult Unauthorized()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}