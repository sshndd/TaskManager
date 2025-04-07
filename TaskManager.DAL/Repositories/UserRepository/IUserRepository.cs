using TaskManager.Common.Models;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUser(string email, CancellationToken cancellationToken = default);
        Task<User> GetUser(string email, string password, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken = default);
        Task<bool> CreateMultiplyUsers(IEnumerable<User> users, CancellationToken cancellationToken = default);
    }
}
