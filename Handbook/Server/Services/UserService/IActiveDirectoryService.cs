using Handbook.Shared;

namespace Handbook.Server.Services.UserService;

public interface IActiveDirectoryService
{
    Task<ActiveDirectoryLogin> GetLoginAsync(string userName);
}