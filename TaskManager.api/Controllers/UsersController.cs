using TaskManager.BLL.Services.UserService;
using TaskManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Common.Models;

namespace TaskManager.api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class UsersController(IUserService userService) : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<ServerResponse>> CreateUser([FromBody] UserModel userModel)
        {
            var response = await userService.CreateUserAsync(userModel);

            if (response.IsSucess == true)
                return Ok(response);
            else
                return BadRequest(response);
        }

    }
}
