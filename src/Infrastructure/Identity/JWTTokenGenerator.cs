using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace CinemaDB.Infrastructure.Identity;
public class JWTTokenGenerator
{
    public static string Generate(int userId, string userName)
    {
        List<Claim> claims = claims = new();
        claims.Add(new Claim("UserId", userId.ToString()));
        claims.Add(new Claim("UserName", userName));
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_123456"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddMinutes(1));
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
