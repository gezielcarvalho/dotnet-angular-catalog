using Backend.Models;
using System.Net;

namespace Backend.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetUsers();
        public Task<(User?, HttpStatusCode)> GetUser(int id);
    }
}