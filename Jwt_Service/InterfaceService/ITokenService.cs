using JWT_Simple.ModelsAuthen;

namespace JWT_Simple.InterfaceService
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);

        Task<bool> VerifyToken(string token);

        Task<string> RefeshToken(string token);
    }
}