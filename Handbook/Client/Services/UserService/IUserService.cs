using Handbook.Shared;

namespace Handbook.Client.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task<bool> AddUserAsync(User user);
        Task<User?> UpdateUserAsync(User user);                                      
        Task<bool> RemoveUserAsync(int id);                                      
    }
}
