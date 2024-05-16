namespace JWT_Simple.Reponse;

public class AuthenticateReponse
{
    public int Id{ get; set; }
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

}
