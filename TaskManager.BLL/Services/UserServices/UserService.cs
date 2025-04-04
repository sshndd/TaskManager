using TaskManager.DAL.Models;
using TaskManager.DAL.Repositories.UserRepository;
using System.Net;
using TaskManager.Common.Models;

namespace TaskManager.BLL.Services.UserService
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<ServerResponse> CreateUserAsync(UserModel userModel, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    Password = userModel.Password,
                    Status = userModel.Status,
                    Phone = userModel.Phone,
                    Photo = userModel.Photo,
                };

                await userRepository.Create(newUser, cancellationToken);
                return new ServerResponse()
                {
                    IsSucess = true,
                    StatusCode = HttpStatusCode.Created,
                    Result = newUser
                };
            }
            catch (Exception ex)
            {
                return new ServerResponse()
                {
                    IsSucess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Что-то пошло не так", ex.Message }
                };
            }

        }
    }
}
