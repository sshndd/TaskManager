using TaskManager.DAL.Models;
using TaskManager.Common.Models;

namespace TaskManager.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<ServerResponse> CreateUserAsync(UserModel userModel, CancellationToken cancellationToken = default);
    }
}
