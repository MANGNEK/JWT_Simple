using JWT_Simple.Helper;
using JWT_Simple.Interface;
using JWT_Simple.InterfaceService;
using JWT_Simple.Models;
using JWT_Simple.ModelsAuthen;
using JWT_Simple.Reponse;
using JWT_Simple.Request;
using Mapster;

namespace JWT_Simple.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, ITokenService tokenService = null)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthenticateReponse> Login(AuthenticateRequest request)
    {
        var userInfo = await _userRepository.GetUserName(request.Username);
        if (userInfo == null) return new AuthenticateReponse();
        if (userInfo.HashPassword != HashPass.MD5Hash(request.Password)) return new AuthenticateReponse();
        var token = _tokenService.CreateToken(userInfo.Adapt<AppUser>());
        await _userRepository.SaveToken(token, userInfo.Id);
        AuthenticateReponse reponse = new AuthenticateReponse() { 
        Token = token,
        Id = userInfo.Id,
        Username = userInfo.UserName,
        LastName = userInfo.Name,
        };
        return reponse;
    }

    public async Task<bool> Register(RegisterRequest request)
    {
        var check = await _userRepository.Checkuser(request.UserName);
        if (check) return false;
        request.HashPassword = HashPass.MD5Hash(request.HashPassword);
       
        await _userRepository.CreateAsync(request.Adapt<AccountUser>());
        _unitOfWork.Save();
        return true;
    }

    public async Task<List<UserReponse>> GetAll()
    {
       var list = await _userRepository.GetAllAsync();
        if(list == null) return new List<UserReponse>();
        return list.Adapt<List<UserReponse>>();
    }

    public async Task<UserReponse> GetById(int id)
    {
        var user = await _userRepository.GetAsync(id);
        if (user == null) return new UserReponse();
        return user.Adapt<UserReponse>();
    }

    public async Task<bool> Update(UpdateUser request)
    {
        var user = await _userRepository.GetAsync(request.Id);
        if (user == null) return false;
        user.Name = request.Name ?? user.Name;
        user.Email = request.Email ?? user.Email;
        _userRepository.UpdateAsync(user);
        _unitOfWork.Save();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
       var user = await _userRepository.GetAsync(id);
       if (user == null) return false;
       _userRepository.DeleteAsync(user);
        _unitOfWork.Save();
       return true;
    }
}
