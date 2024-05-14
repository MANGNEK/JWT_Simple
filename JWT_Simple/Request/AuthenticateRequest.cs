using System.ComponentModel.DataAnnotations;

namespace JWT_Simple.Request;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}
public class RegisterRequest
{
    [Required] public string UserName { get; set; } = string.Empty;
    [Required] public string HashPassword { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
public class UpdateUser
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
