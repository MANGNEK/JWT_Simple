using JWT_Simple.Reponse;
using JWT_Simple.Request;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JWT_Simple.InterfaceService;

public interface IUserService
{
    Task<AuthenticateReponse> Login(AuthenticateRequest request);
    Task<bool> Register(RegisterRequest request);
    Task<List<UserReponse>> GetAll();
    Task<UserReponse> GetById(int id);
    Task<bool> Update(UpdateUser request);
    Task<bool> Delete(int id);
}
