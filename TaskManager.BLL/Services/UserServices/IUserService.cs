using TaskManager.DAL.Models;
using TaskManager.Common.Models;

namespace TaskManager.BLL.Services.UserServices
{
    public interface IUserService
    {
        Task<ServerResponse> CreateUserAsync(UserModel userModel, CancellationToken cancellationToken = default);
        Task<ServerResponse> UpdateUserAsync(int id, UserModel userModel, CancellationToken cancellation = default);
        Task<ServerResponse> DeleteUserAsync(int id, CancellationToken cancellationToken = default);
        //Task<ServerResponse> GetUsers(CancellationToken cancellationToken = default);
        Task<ServerResponse> GetAllUsers(CancellationToken cancellationToken = default);
        Task<ServerResponse> CreateMuitiplyUsersAsync(List<UserModel> userModels, CancellationToken cancellationToken = default);
    }
}
