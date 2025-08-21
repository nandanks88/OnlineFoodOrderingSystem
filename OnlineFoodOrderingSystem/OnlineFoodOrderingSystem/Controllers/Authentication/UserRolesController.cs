using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodOrderingSystem.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserRolesController : ControllerBase
    {


        //public Task<> getRole()
        //{


        //}

    }
}
