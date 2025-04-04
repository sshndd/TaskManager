using TaskManager.Common.Models;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task <IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken);
        Task<bool> CreateMultiplyUsers(List<User> users, CancellationToken cancellationToken);
    }
}
