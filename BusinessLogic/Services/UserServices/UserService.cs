using DataAccess.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.api.Models;
using TaskManager.Common.Models;

namespace BusinessLogic.Services.UserServices
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task CreateUserAsync(UserModel userDto, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                Status = userDto.Status,
                Phone = userDto.Phone,
                Photo = userDto.Photo,
            };

            await userRepository.CreateUserAsync(newUser, cancellationToken);
        }
    }
}
