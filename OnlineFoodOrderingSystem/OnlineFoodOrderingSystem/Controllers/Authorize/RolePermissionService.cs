using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodOrderingSystem.Controllers.Authorize
{
    public class RolePermissionService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
