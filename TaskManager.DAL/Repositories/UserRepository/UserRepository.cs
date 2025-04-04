using TaskManager.DAL.Data;
using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Models;
using TaskManager.Common.Models;
using System.Threading.Tasks;
using System;

namespace TaskManager.DAL.Repositories.UserRepository
{
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<bool> Create(User entity, CancellationToken cancellationToken = default)
        {
            await context.Users.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> CreateMultiplyUsers(List<User> users, CancellationToken cancellationToken)
        {
            await context.Users.AddRangeAsync(users, cancellationToken);
            await context.SaveChangesAsync(cancellationToken); 
            return true;
        }

        public async Task<bool> Delete(User entity, CancellationToken cancellationToken = default)
        {
            context.Users.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return true;

        }

        public async Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken = default)
        {
            return await context.Users.Select(u => u.ToDto()).ToListAsync(cancellationToken);
        }

        public async Task<User> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public Task<List<User>> Select(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(User entity, CancellationToken cancellationToken = default)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
