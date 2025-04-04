using TaskManager.DAL.Models;
using TaskManager.DAL.Repositories.UserRepository;
using System.Net;
using TaskManager.Common.Models;

namespace TaskManager.BLL.Services.UserServices
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<ServerResponse> CreateMuitiplyUsersAsync(List<UserModel> userModels, CancellationToken cancellationToken = default)
        {
            if (userModels != null && userModels.Count > 0)
            {
                var newUsers = userModels.Select(u => new User(u));
                await userRepository.CreateMultiplyUsers((List<User>)newUsers, cancellationToken);
                return new ServerResponse()
                {
                    IsSucess = true,
                    StatusCode = HttpStatusCode.OK,
                };
            }
            return new ServerResponse()
            {
                IsSucess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = {"Список данных пуст"}

            };
        }

        public async Task<ServerResponse> CreateUserAsync(UserModel userModel, CancellationToken cancellationToken)
        {
            try
            {
                if (userModel != null)
                {
                    var newUser = new User(userModel.FirstName, userModel.LastName, userModel.Email,
                        userModel.Password, userModel.Status,userModel.Phone, userModel.Photo);

                    await userRepository.Create(newUser, cancellationToken);
                    return new ServerResponse()
                    {
                        IsSucess = true,
                        StatusCode = HttpStatusCode.Created
                    };
                }
                return new ServerResponse()
                {
                    IsSucess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Модель данных пуста" }
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

        public async Task<ServerResponse> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var userForDelete = await userRepository.GetById(id, cancellationToken);
                if (userForDelete == null)
                {
                    return new ServerResponse()
                    {
                        IsSucess = false,
                        StatusCode = HttpStatusCode.NotFound,
                        ErrorMessages = {"Пользователь не найден"}
                    };
                }

                await userRepository.Delete(userForDelete, cancellationToken);
                return new ServerResponse()
                {
                    IsSucess= true,
                    StatusCode = HttpStatusCode.OK
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

        public async Task<ServerResponse> GetAllUsers(CancellationToken cancellationToken = default)
        {
            var users = await userRepository.GetAll(cancellationToken);
            if (users != null)
            {
                return new ServerResponse()
                {
                    IsSucess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = users
                };
            }
            return new ServerResponse()
            {
                IsSucess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = { "Ничего не найдено" }
            };
        }

        public async Task<ServerResponse> UpdateUserAsync(int id, UserModel userModel, CancellationToken cancellationToken)
        {
            try
            {
                if (userModel != null)
                {
                    var userForUpdate = await userRepository.GetById(id, cancellationToken);
                    if (userForUpdate == null)
                    {
                        return new ServerResponse()
                        {
                            IsSucess = false,
                            StatusCode = HttpStatusCode.NotFound,
                            ErrorMessages = { "Пользователь не найден" }
                        };
                    }

                    userForUpdate.FirstName = userModel.FirstName;
                    userForUpdate.LastName = userModel.LastName;
                    userForUpdate.Email = userModel.Email;
                    userForUpdate.Password = userModel.Password;
                    userForUpdate.Phone = userModel.Phone;
                    userForUpdate.Photo = userModel.Photo;
                    userForUpdate.Status = userModel.Status;

                    await userRepository.Update(userForUpdate);

                    return new ServerResponse()
                    {
                        IsSucess = true,
                        StatusCode = HttpStatusCode.OK
                    };
                }
                return new ServerResponse()
                {
                    IsSucess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = { "Модель данных пуста" }
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
