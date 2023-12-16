using Backend.Models;

namespace Backend.Services
{
    public class UsersService : IUsersService
    {
        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();
            // simulate an async call
            await Task.Delay(1000);
            return users;
        }

        public async Task<User> GetUser()
        {
            var user = new User();
            // simulate an async call
            await Task.Delay(1000);
            return user;
        }
    }
}
