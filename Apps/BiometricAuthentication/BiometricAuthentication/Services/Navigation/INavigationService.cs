namespace BiometricAuthentication.Services.Navigation
{
    public interface INavigationService
    {
        Task GoBackAsync(IDictionary<string, object>? routeParameters = null);
        Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null);
    }
}
