using TaskManager.BLL.Services.UserServices;
using TaskManager.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Common.Models;
using System.Net;

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

        [HttpPatch("{id}")]
        public async Task<ActionResult<ServerResponse>> UpdateUser(int id, [FromBody] UserModel userModel)
        {
            var response = await userService.UpdateUserAsync(id, userModel);

            if (response.IsSucess == true)
                return Ok(response);
            else if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            else 
                return BadRequest(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServerResponse>> DeleteUser(int id)
        {
            var response = await userService.DeleteUserAsync(id);

            if (response.IsSucess == true)
                return Ok(response);
            else if (response.StatusCode == HttpStatusCode.NotFound)
                return NotFound(response);
            else
                return BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServerResponse>> GetAllUsers()
        {
            var response = await userService.GetAllUsers();
            if (response.IsSucess == true)
                return Ok(response);
            else 
                return NotFound(response);
            
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse>> CreateMultUsers([FromBody] List<UserModel> userModels)
        {
            var response = await userService.CreateMuitiplyUsersAsync(userModels);
            if (response.IsSucess == true)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
