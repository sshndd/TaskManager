using TaskManager.DAL.Models;
using TaskManager.Common.Models;

namespace TaskManager.BLL.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserModel userModel, CancellationToken cancellationToken = default);
        Task<bool> UpdateUserAsync(int id, UserModel userModel, CancellationToken cancellationToken = default);
        Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> CreateMuitiplyUsersAsync(List<UserModel> userModels, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserModel>> GetUsersAsync(CancellationToken cancellationToken = default);
    }
}
