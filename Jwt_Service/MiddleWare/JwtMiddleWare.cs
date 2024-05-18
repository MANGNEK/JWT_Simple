using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JWT_Simple.Helper;
using JWT_Simple.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Jwt_Service.MiddleWare;

public class JwtMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    public JwtMiddleWare(RequestDelegate requestDelegate, IConfiguration configuration)
    {
        _next = requestDelegate;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null) await AddUserToContext(context, userService, token);
        await _next(context);
    }

    public async Task AddUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
                
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(e => e.Type == "nameid").Value);
            var user = await userService.GetById(userId);
        }
        catch
        { 
        }
    }
}