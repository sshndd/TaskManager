using Microsoft.EntityFrameworkCore;
using TaskManager.Common.Models;
using TaskManager.DAL.Data;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories.UserRepository
{
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<bool> Create(User model, CancellationToken cancellationToken = default)
        {
            try
            {
                await context.AddAsync(model, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateMultiplyUsers(IEnumerable<User> users, CancellationToken cancellationToken = default)
        {
            try
            {
                await context.AddRangeAsync(users, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(User model, CancellationToken cancellationToken = default)
        {
            try
            {
                context.Users.Remove(model);
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> Get(int id, CancellationToken cancellationToken = default)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<User> GetUser(string email, CancellationToken cancellationToken = default)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<bool> Update(User model, CancellationToken cancellationToken = default)
        {
            try
            {
                context.Users.Update(model);
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken = default)
        {
            return await context.Users.Select(u => u.ToDto()).ToListAsync(cancellationToken);
        }

        public async Task<User> GetUser(string email, string password, CancellationToken cancellationToken = default)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password, cancellationToken);
        }
    }
}
