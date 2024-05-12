using JWT_Simple.Context;
using JWT_Simple.Interface;
using JWT_Simple.Repository;
using Microsoft.EntityFrameworkCore;

namespace JWT_Simple.DbConfig;

public static class DatabaseConfig
{
    public static void ConfigDataBase(this IServiceCollection serviceColectionScope , IConfiguration configuration)
    {
        var conectionString = configuration.GetValue<string>("ConnectionStrings:DbConnection") ?? "Server=DEVNET\\NETDEV;Database=JwTUser;Integrated Security=True;";
        serviceColectionScope.AddDbContext<JwtContext>(
            option => option.UseSqlServer(conectionString));
        serviceColectionScope.AddScoped<IUnitOfWork,UnitOfWork>();
    }
}
