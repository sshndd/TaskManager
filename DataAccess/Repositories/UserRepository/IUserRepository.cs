using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.api.Models;

namespace DataAccess.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
    }
}
