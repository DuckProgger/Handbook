using Handbook.Shared;

namespace Handbook.Server.Services.UserService;

public interface IActiveDirectoryService
{
    /// <summary>
    /// Получить логин пользователя Active Directory.
    /// </summary>
    /// <param name="userName">Имя пользователя.</param>
    /// <returns></returns>
    Task<ActiveDirectoryLogin> GetLoginAsync(string userName);
}