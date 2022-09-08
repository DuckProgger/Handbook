using System.Net.Http.Json;
using Handbook.Shared;

namespace Handbook.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory clientFactory;

        public UserService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var client = clientFactory.CreateClient(nameof(IUserService));
            return await client.GetFromJsonAsync<List<User>>("all");
        }

        public async Task<User?> GetUserAsync(int id)
        {
            var client = clientFactory.CreateClient(nameof(IUserService));
            return await client.GetFromJsonAsync<User>($"{id}");
        }

        public async Task<bool> AddUserAsync(User user)
        {
            var client = clientFactory.CreateClient(nameof(IUserService));
            var response = await client.PostAsJsonAsync("add", user);
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            var client = clientFactory.CreateClient(nameof(IUserService));
            var response = await client.PutAsJsonAsync("update", user);
            return await response.Content.ReadFromJsonAsync<User?>();
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            var client = clientFactory.CreateClient(nameof(IUserService));
            var response = await client.PutAsJsonAsync("delete", id);
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
