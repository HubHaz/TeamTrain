namespace TeamTrain.Application.DTOs.Auth;

public class AuthResult
{
    public bool Success { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string[] Errors { get; set; }
}