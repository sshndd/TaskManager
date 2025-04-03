using BusinessLogic.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Common.Models;

namespace TaskManager.api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class UsersController(IUserService userService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserModel userModel)
        {
            await userService.CreateUserAsync(userModel);
            return NoContent();
        }

    }
}
