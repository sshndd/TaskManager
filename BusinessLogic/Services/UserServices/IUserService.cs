using DataAccess.Models;
using TaskManager.Common.Models;

namespace BusinessLogic.Services.UserService
{
    public interface IUserService
    {
        Task<ServerResponse> CreateUserAsync(UserModel userModel, CancellationToken cancellationToken = default);
    }
}
