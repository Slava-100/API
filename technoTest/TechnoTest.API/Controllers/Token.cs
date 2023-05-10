using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechnoTest.API.Models;

namespace TechnoTest.API.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class Token : ControllerBase
    {
        private readonly JWTSettings _options;

        public Token(IOptions<JWTSettings> optAcces)
        {
            _options = optAcces.Value;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetToken()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Svyat"));
            claims.Add(new Claim("level", "123"));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                        issuer: _options.Issuer,
                        audience: _options.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
