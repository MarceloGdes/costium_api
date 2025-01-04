
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Costium.Infra.Services;
public class JwtTokenService(IConfiguration config)
{
    private readonly IConfiguration _config = config;

    public string GenerateToken(string userId)
    {

        var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim("userId", userId)
            ]),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);


        //var claims = new[]
        //{
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    new Claim(JwtRegisteredClaimNames.Sub, userId)
        //};

        //var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));
        //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //var token = new JwtSecurityToken(
        //    claims: claims,
        //    expires: DateTime.Now.AddHours(2),
        //    signingCredentials: creds
        //);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
