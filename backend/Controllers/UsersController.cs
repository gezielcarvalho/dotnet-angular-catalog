using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetUser")]
        public async Task<ActionResult> GetUser()
        {
            var user = await _service.GetUser();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _service.GetUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}
