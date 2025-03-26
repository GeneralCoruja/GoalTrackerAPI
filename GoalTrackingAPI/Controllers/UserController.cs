namespace GoalTrackingAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GoalTrackingAPI.Database.Models;
    using GoalTrackingAPI.Identity;
    using GoalTrackingAPI.Services;
    using GoalTrackingAPI.Dtos.Users;
    using System.Linq;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return (await _userService.GetAllAsync()).Select(x => x.ToDTO());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserDto>> Get(string username)
        {
            var user = await _userService.GetByUsername(username);
            if (user is null)
            {
                return NotFound();
            }

            return user.ToDTO();
        }

        [HttpDelete()]
        [RequiresClaim(Claims.Admin, "true")]
        public async Task<ActionResult<User>> DeleteByUsername([FromBody] string username)
        {
            try
            {
                await _userService.DeleteByUsername(username);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
