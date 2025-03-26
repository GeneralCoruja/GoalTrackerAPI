using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GoalTrackingAPI.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static void AddJWTAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = (string)builder.Configuration.GetSection("JwtTokens").GetValue(typeof(string), "Issuer"),
                    ValidAudience = (string)builder.Configuration.GetSection("JwtTokens").GetValue(typeof(string), "Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes((string)builder.Configuration.GetSection("JwtTokens").GetValue(typeof(string), "Key"))),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
            });
        }
    }
}
