using DatingApp.API.Databases.Entities;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    // [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userService.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user is null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            var currentUser = _userService.GetUserById(id);
            if (currentUser is null) return NotFound();
            currentUser.Username = user.Username;
            currentUser.Email = user.Email;
            _userService.UpdateUser(currentUser);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var currentUser = _userService.GetUserById(id);
            if (currentUser is null) return NotFound();
            _userService.DeleteUser(currentUser);
            return Ok();
        }
    }
}