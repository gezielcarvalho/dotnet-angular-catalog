using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            var users = await _service.GetUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var (user, statusCode) = await _service.GetUser(id);
            if (statusCode == HttpStatusCode.NotFound || statusCode == 0)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
