using System.ComponentModel.DataAnnotations;

namespace JWT_Simple.Models;

public class AccountUser
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string HashPassword { get; set; } = string.Empty ;
    public string Token { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string ResfeshToken {  get; set; } = string.Empty ;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;  
}
