using TaskManager.BLL.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Common.Models;

namespace TaskManager.api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await userService.GetUsersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                return Ok(await userService.CreateUserAsync(userModel));
            }
            return BadRequest("Модель данных пуста");
        }

        [HttpPost]
        public async Task<IActionResult> CreateMuitiplyUsers([FromBody] List<UserModel> userModels)
        {
            if (userModels != null && userModels.Count > 0)
            {
                return Ok(await userService.CreateMuitiplyUsersAsync(userModels));
            }
            return BadRequest("Модель данных пуста");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                return await userService.UpdateUserAsync(id, userModel) ? Ok("Успешно обновлено") : NotFound("Пользователь не найден");
            }
            return BadRequest("Модель данных пуста");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return await userService.DeleteUserAsync(id) ? Ok("Успешно удалено") : NotFound("Пользователь не найден");
        }
    }
}
