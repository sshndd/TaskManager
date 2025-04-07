using TaskManager.DAL.Models;
using TaskManager.DAL.Repositories.UserRepository;
using System.Net;
using TaskManager.Common.Models;

namespace TaskManager.BLL.Services.UserServices
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<bool> CreateMuitiplyUsersAsync(List<UserModel> userModels, CancellationToken cancellationToken = default)
        {
            var newUsers = userModels.Select(u => new User(u));
            return await userRepository.CreateMultiplyUsers(newUsers, cancellationToken);
        }

        public async Task<bool> CreateUserAsync(UserModel userModel, CancellationToken cancellationToken = default)
        {
            var newUser = new User(userModel.FirstName, userModel.LastName, userModel.Email, userModel.Password, userModel.Status, userModel.Phone, userModel.Photo);
            return await userRepository.Create(newUser, cancellationToken);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken = default)
        {
            var deletingUser = await userRepository.Get(id, cancellationToken);
            if (deletingUser != null)
            {
                return await userRepository.Delete(deletingUser, cancellationToken);
            }
            return false;
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await userRepository.GetUsers(cancellationToken);
        }

        public async Task<bool> UpdateUserAsync(int id, UserModel userModel, CancellationToken cancellationToken = default)
        {
            var updatingUser = await userRepository.Get(id, cancellationToken);
            if (updatingUser != null)
            {
                updatingUser.FirstName = userModel.FirstName;
                updatingUser.LastName = userModel.LastName;
                updatingUser.Email = userModel.Email;
                updatingUser.Password = userModel.Password;
                updatingUser.Phone = userModel.Phone;
                updatingUser.Photo = userModel.Photo;
                updatingUser.Status = userModel.Status;

                return await userRepository.Update(updatingUser, cancellationToken);
            }
            return false;
        }
    }
}
