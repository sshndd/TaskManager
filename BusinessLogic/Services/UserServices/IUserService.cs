using TaskManager.Common.Models;

namespace BusinessLogic.Services.UserServices
{
    public interface IUserService
    {
        Task CreateUserAsync(UserModel userDto, CancellationToken cancellationToken = default);
    }
}
