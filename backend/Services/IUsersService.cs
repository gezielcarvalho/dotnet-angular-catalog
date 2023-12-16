using Backend.Models;

namespace Backend.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUser();
    }
}