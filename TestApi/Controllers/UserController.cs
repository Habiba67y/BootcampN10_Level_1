using Microsoft.AspNetCore.Mvc;
using TestBackend.Models;
using TestBackend.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("user")]
        public User AddUser([FromBody]User user)
        {
            user.Id = Guid.NewGuid();
            _userService.AddUser(user);
            return user;
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }
        [HttpGet("Id")]
        public User GetId(Guid id)
        {
            return _userService.GetById(id);
        }
        [HttpPut("user")]
        public User Update(User user)
        {
            return _userService.Update(user);
        }
        [HttpDelete("user")]
        public User Delete(User user)
        {
            return _userService.Delete(user);
        }
    }
}
