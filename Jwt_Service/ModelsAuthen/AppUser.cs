using Microsoft.AspNetCore.Identity;

namespace JWT_Simple.ModelsAuthen;

public class AppUser : IdentityUser
{
    public string Role { get; set; } = string.Empty;
}
