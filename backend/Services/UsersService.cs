using Backend.Models;
using System.Net;

namespace Backend.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<User>> GetUsers()
        {
            var usersURI = new Uri("https://jsonplaceholder.typicode.com/users");
            var response = await _httpClient.GetAsync(usersURI);
            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<User>>();
                return users!;
            }
            return null!;
        }

        public async Task<(User?, HttpStatusCode)> GetUser(int id)
        {
            var usersURI = new Uri($"https://jsonplaceholder.typicode.com/users/{id}");
            var response = await _httpClient.GetAsync(usersURI);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<User>();
                return (user, HttpStatusCode.OK);
            }
            else
            {
                // Return the status code along with null for user
                return (null, response.StatusCode);
            }
        }


    }
}
