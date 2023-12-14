using Backend.Models;

namespace Backend.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetUsers();
    }
}