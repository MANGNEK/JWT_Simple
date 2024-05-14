using JWT_Simple.Context;
using JWT_Simple.GenericRepository;
using JWT_Simple.Interface;
using JWT_Simple.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_Simple.Repository;

public class UserRepository :GenericRepository<AccountUser>,IUserRepository
{
    private readonly JwtContext _jwtContext;
    public UserRepository(JwtContext context) : base(context) {
        _jwtContext = context;
    }
    public async Task<bool> Checkuser(string user)
    {
        var userInDb = await _jwtContext.Set<AccountUser>().FirstOrDefaultAsync(e => e.UserName == user);
        if (userInDb != null) return true;
        return false;
    }

    public async Task<AccountUser> GetUserName(string username)
    {
        var user = await _jwtContext.Set<AccountUser>().FirstOrDefaultAsync(e => e.UserName == username);
        if(user == null) return new AccountUser();
        return user;
    }
}
