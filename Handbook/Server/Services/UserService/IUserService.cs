using Handbook.Shared;

namespace Handbook.Server.Services.UserService;

public interface IUserService
{
    /// <summary>
    /// Получить всех пользователей.
    /// </summary>
    /// <returns>Список пользователей.</returns>
    Task<List<User>> GetAllUsersAsync();
    /// <summary>
    /// Получить пользователя.
    /// </summary>
    /// <param name="id">ID пользователя.</param>
    /// <returns>Найденный пользователь, если он существует, в противном случае - null.</returns>
    Task<User?> GetUserAsync(int id);
    /// <summary>
    /// Добавить нового пользователя.
    /// </summary>
    /// <param name="user">Новый пользователь.</param>
    /// <returns>true - если пользователь добавлен, false - если не удалось добавить.</returns>
    Task<bool> AddUserAsync(User user);
    /// <summary>
    /// Обновить существующего пользователя.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <returns>Обновлённый пользователь, если он успешно изменён, в противном случае - null.</returns>
    Task<User?> UpdateUserAsync(User user);    
    /// <summary>
    /// Удалить пользователя.
    /// </summary>
    /// <param name="id">ID пользователя.</param>
    /// <returns>true - если пользователь удалён, false - если не удалось добавить.</returns>
    Task<bool> RemoveUserAsync(int id);                                      
}