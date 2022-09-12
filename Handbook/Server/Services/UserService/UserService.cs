using Handbook.Server.Data;
using Handbook.Shared;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Server.Services.UserService;

public class UserService : IUserService
{
    private readonly ApplicationContext db;
    private readonly IActiveDirectoryService adService;

    public UserService(ApplicationContext db, IActiveDirectoryService adService)
    {
        this.db = db;
        this.adService = adService;
    }
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await db.Users
            .Where(u => u.Active)
            .Include(u => u.ActiveDirectoryLogin)
            .ToListAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> AddUserAsync(User user)
    {
        user.Active = true;
        user.ActiveDirectoryLogin = await adService.GetLoginAsync($"{user.FirstName} {user.LastName}");
        await db.Users.AddAsync(user);
        var entries = await db.SaveChangesAsync();
        return entries > 0;
    }

    public async Task<User?> UpdateUserAsync(User user)
    {
        var existingUser = await db.Users
            .Include(u => u.ActiveDirectoryLogin)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == user.Id);
        if (existingUser is null) return null;
        // Обновить пользователя.
        db.Entry(user).State = EntityState.Modified;
        await db.SaveChangesAsync();
        // Обновить логин Active Directory.
        user.ActiveDirectoryLogin = await adService.GetLoginAsync($"{user.FirstName} {user.LastName}");
        await AddOrUpdateActiveDirectoryLogin(user.ActiveDirectoryLogin, existingUser.ActiveDirectoryLogin);
        return user;
    }

    public async Task<bool> RemoveUserAsync(int id)
    {
        var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (existingUser is null) return false;
        existingUser.Active = false;
        db.Entry(existingUser).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return true;
    }

    private async Task AddOrUpdateActiveDirectoryLogin(ActiveDirectoryLogin newLogin, ActiveDirectoryLogin? oldLogin)
    {
        var existingLogin = oldLogin is null
            ? null
            : await db.ADLogins
            .FirstOrDefaultAsync(l => l.Domain == oldLogin.Domain && l.Login == oldLogin.Login);
        // Обновить логин Active Directory.
        if (existingLogin is not null)
        {
            existingLogin.Domain = newLogin.Domain;
            existingLogin.Login = newLogin.Login;
            db.Entry(existingLogin).State = EntityState.Modified;
        }
        // Создать логин Active Directory.
        else
            db.Entry(newLogin).State = EntityState.Added;
        await db.SaveChangesAsync();
    }
}