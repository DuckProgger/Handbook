using Handbook.Shared;

namespace Handbook.Server.Services.UserService;

class ActiveDirectoryService : IActiveDirectoryService
{
    public Task<ActiveDirectoryLogin> GetLoginAsync(string userName)
    {
        // Заглушка.
        var adLogin = new ActiveDirectoryLogin()
        {
            Domain = "CompanyDomain",
            Login = userName
        };
        return Task.FromResult(adLogin);
    }
}