namespace GoalTrackingAPI.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using GoalTrackingAPI.Domain.Models.Users;
    using GoalTrackingAPI.Domain.Services;
    using GoalTrackingAPI.Dtos.Identity;
    using GoalTrackingAPI.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    [ApiController]
    [Route("identity")]
    public class IdentityController : Controller
    {
        private readonly string TokenSecret;
        private readonly TimeSpan TokenLifeTime;
        private readonly string TokenIssuer;
        private readonly string TokenAudience;

        private IdentityService _identityService;
        private UserService _userService;

        public IdentityController(IOptions<JwtTokenConfig> tokenConfig, UserService userService, IdentityService identityService)
        {
            _identityService = identityService;
            _userService = userService;

            TokenSecret = tokenConfig.Value.Key;
            TokenLifeTime = TimeSpan.FromMinutes(tokenConfig.Value.TokenLifetime);
            TokenIssuer = tokenConfig.Value.Issuer;
            TokenAudience = tokenConfig.Value.Audience;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto request)
        {
            //fetch user by username
            var user = await _userService.GetByUsername(request.Username);
            if (user == null)
            {
                return BadRequest();
            }

            //validate if password is correct before returning token
            var validatePassword = await _identityService.ValidatePasswordHash(request.Password, user.Password);
            if (validatePassword)
            {
                return Ok(GenerateToken(user));
            }

            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationDto request)
        {
            var user = await _identityService.RegisterUser(request.ToDomain());
            if (user == null)
            {
                return BadRequest();
            }

            return Ok(GenerateToken(user));
        }

        // TEMPORARY: token gen logic needs to be moved somewhere else
        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("userId", user.Id.ToString()),
                new Claim("firstname", user.FirstName),
                new Claim("lastname", user.LastName)
            };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(Claims.Admin, "true"));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                Issuer = TokenIssuer,
                Audience = TokenAudience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
