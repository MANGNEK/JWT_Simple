using JWT_Simple.InterfaceService;
using JWT_Simple.ModelsAuthen;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Simple.Services;

public class TokenService : ITokenService
{
    public readonly IConfiguration Configuration;
    public readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration configuration)
    {
        Configuration = configuration;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]));
    }

    public string CreateToken(AppUser appUser)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, appUser.Id)
,           new Claim(JwtRegisteredClaimNames.Email ,appUser.Email),
            new Claim("UserName", appUser.UserName),
            new Claim(JwtRegisteredClaimNames.GivenName, appUser.Role),
        };

        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = cred,
            Issuer = Configuration["JWT:Issuer"],
            Audience = Configuration["JWT:Audience"]
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public Task<string> RefeshToken(string Token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyToken(string token)
    {
        throw new NotImplementedException();
        //var jwtTokenHandler = new JwtSecurityTokenHandler();
        //var tokenReader = jwtTokenHandler.ReadJwtToken(token);
        //var id = tokenReader.
    }
}