namespace GoalTrackingAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GoalTrackingAPI.Database.Models;
    using GoalTrackingAPI.Identity;
    using GoalTrackingAPI.Services;

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
        public async Task<IEnumerable<User>> GetAll() {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user is null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpDelete()]
        [RequiresClaim(Claims.Admin, "true")]
        public async Task<ActionResult<User>> DeleteByUsername([FromBody] string username)
        {
            try
            {
                await _userService.DeleteByUsername(username);
            }
            catch (Exception ex) {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
