using SIS.MvcFramework.ActionResults.Contracts;
using SIS.MvcFramework.Controllers;

namespace SIS.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
