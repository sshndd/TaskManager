using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using TaskManager.api.Models;

namespace DataAccess.Repositories.UserRepository
{
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<bool> Create(User entity, CancellationToken cancellationToken = default)
        {
            await context.Users.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> Delete(User entity, CancellationToken cancellationToken = default)
        {
            context.Users.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return true;

        }

        public async Task<User> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<User>> Select(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
