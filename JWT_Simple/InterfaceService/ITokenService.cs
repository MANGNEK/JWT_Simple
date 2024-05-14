using JWT_Simple.ModelsAuthen;

namespace JWT_Simple.InterfaceService
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
