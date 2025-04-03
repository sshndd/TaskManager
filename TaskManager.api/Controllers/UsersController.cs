using BusinessLogic.Services.UserService;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Common.Models;

namespace TaskManager.api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class UsersController(IUserService userService) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<ServerResponse>> CreateUserAsync([FromBody] UserModel userModel)
        {
            var response = await userService.CreateUserAsync(userModel);
            return response;
        }

    }
}
