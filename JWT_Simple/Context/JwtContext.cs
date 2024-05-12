using JWT_Simple.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_Simple.Context;

public class JwtContext : DbContext
{
    public JwtContext(DbContextOptions<JwtContext> options) : base(options) { }
    public DbSet<AccountUser> accountUsers { get; set; }
}

