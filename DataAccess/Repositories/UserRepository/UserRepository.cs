using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.api.Models;

namespace DataAccess.Repositories.UserRepository
{
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await context.Users.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
