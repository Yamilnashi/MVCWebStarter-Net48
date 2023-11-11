using System.Web.Mvc;
using WebMvc.ViewModels.Profile;

namespace WebMvc.Controllers
{
    [RoutePrefix("Profile")]
    public class ProfileController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            var model = new MyProfileIndexViewModel()
            {
                UserGuid = new System.Guid(),
                GivenName = "Alex",
                MiddleName = "Jordan",
                Surname = "Smith",
                Biography = "Alex is a dedicated professional with over 10 years of experience in software development. Known for innovative problem-solving skills and a passion for technology.",
                ManagerName = "Taylor Morgan",
                Title = "Senior Software Developer",
                Division = "Division of Information Technology",
                Branch = "Application Development",
                PhoneNumber = "(555) 123-4567",
                EmailAddress = "alex.smith@example.com"
        };                       
            
            return View(model);
        }
    }
}