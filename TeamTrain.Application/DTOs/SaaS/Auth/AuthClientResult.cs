namespace TeamTrain.Application.DTOs.SaaS.Auth;

public class AuthClientResult
{
    public bool Success { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public List<string> Errors { get; set; }
}