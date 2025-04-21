namespace BiometricAuthentication.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string reason);
    }
}
