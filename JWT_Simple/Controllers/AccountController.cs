using JWT_Simple.Interface;
using JWT_Simple.InterfaceService;
using JWT_Simple.Reponse;
using JWT_Simple.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Simple.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Resgister([FromBody] RegisterRequest request)
    {
        var resuilt = await _userService.Register(request);
        if (!resuilt) return BadRequest("Some Thing Wrong !!!");
        return Ok("Resgister Success!!");
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] AuthenticateRequest request)
    {
        var result = await _userService.Login(request);
        if (result == null) return BadRequest("Login Fail");
        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    [Route("getAll")]
    public async Task<List<UserReponse>> GetAll()
    {
        return await _userService.GetAll();
    }

    [Authorize]
    [HttpGet]
    [Route("getUser")]
    public async Task<UserReponse> GetUser(int id)
    {
        return await _userService.GetById(id);
    }

    [Authorize]
    [HttpPatch]
    [Route("update")]
    public async Task<bool> UpdateUser([FromBody] UpdateUser user)
    {
        return await _userService.Update(user);
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete]
    [Route("delete")]
    public async Task<bool> Delete(int id)
    {
        return await _userService.Delete(id);
    }
}