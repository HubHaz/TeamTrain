namespace TeamTrain.Application.DTOs.Tenant.Auth;

public class AuthResult
{
    public bool Success { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public List<string> Errors { get; set; }
}