namespace TeamTrain.Domain;

public static class Consts
{
    public const int UsernameMinLength = 5;

    public const string PasswordRegex = @"^(?=.*[A-Z])(?=.*[\W])(?=.*[0-9])(?=.*[a-z]).{6,128}$";

    public static class JwtClaimIdentifiers
    {
        public const string Id = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        public const string UserName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        public const string Email = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
    }
}