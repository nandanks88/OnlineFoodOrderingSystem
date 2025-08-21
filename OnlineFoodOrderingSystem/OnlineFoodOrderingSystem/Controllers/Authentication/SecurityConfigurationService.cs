using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodOrderingSystem.Controllers.Authentication
{
    public class SecurityConfigurationService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
