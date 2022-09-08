using Handbook.Server.Data;
using Handbook.Shared;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext context;

        public UserService(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            var entries = await context.SaveChangesAsync();
            return entries > 0;
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser is null) return null;
            var entry = context.Users.Update(user);
            await context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser is null) return false;
            context.Users.Remove(existingUser);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
