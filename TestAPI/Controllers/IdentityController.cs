namespace TestAPI.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using DocumentFormat.OpenXml.Spreadsheet;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using TestAPI.Database;
    using TestAPI.Database.Models;
    using TestAPI.Dtos;
    using TestAPI.Services;

    [ApiController]
    [Route("identity")]
    public class IdentityController : Controller
    {
        private const string TokenSecret = "TOKENSECRETTOKENSECRETTOKENSECRETTOKENSECRET";
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromMinutes(60);
        private MongoDatabase _database;
        private IdentityService _identityService;

        public IdentityController(MongoDatabase database, IdentityService identityService)
        {
            _database = database;
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto request) {
            //fetch user by username
            var user = await _database.Users.GetByUsernameAsync(request.Username);
            if (user == null) {
                return BadRequest();
            }

            //validate if password is correct before returning token
            var validatePassword = await _identityService.ValidatePasswordHash(request.Password, user.Password);
            if (validatePassword) {
                return Ok(GenerateToken(user));
            }

            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationDto request)
        {
            // validate the username is unique
            var existingUser = await _database.Users.GetByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return BadRequest();
            }

            // create user
            var user = new User { 
                Username = request.Username,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Password = _identityService.ComputeHash(request.Password),
                Email = request.Email,
            };
            await _database.Users.CreateAsync(user);

            return Ok(GenerateToken(user));
        }

        private string GenerateToken(User user) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("userId", user.Id.ToString()),
                new Claim("firstname", user.Firstname),
                new Claim("lastname", user.Lastname)
            };

            // // Custom Claims
            //foreach (var claimPair in request.CustomClaims) {
            //    var jsonElement = (JsonElement)claimPair.Value;
            //    var valueType = jsonElement.ValueKind switch
            //    {
            //        JsonValueKind.True => ClaimValueTypes.Boolean,
            //        JsonValueKind.False => ClaimValueTypes.Boolean,
            //        JsonValueKind.Number => ClaimValueTypes.Double,
            //        _ => ClaimValueTypes.String
            //    };

            //    var claim = new Claim(claimPair.Key, claimPair.Value.ToString()!, valueType);
            //    claims.Add(claim);
            //}

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                Issuer = "issuerCert",
                Audience = "app",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
