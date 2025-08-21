using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodOrderingSystem.Controllers.Authorize
{
    public class AuthorizationService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
