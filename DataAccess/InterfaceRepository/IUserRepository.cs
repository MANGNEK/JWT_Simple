using JWT_Simple.Models;
namespace JWT_Simple.Interface;

public interface IUserRepository : IGenericRepository<AccountUser>
{
    Task<bool> Checkuser(string user);
    Task<AccountUser> GetUserName(string username);
    Task SaveToken(string token, int Id);
}
