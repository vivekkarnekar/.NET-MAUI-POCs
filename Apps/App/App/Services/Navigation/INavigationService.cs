namespace App.Services.Navigation
{
    public interface INavigationService
    {
        Task GoBackAsync();
        Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null);
    }
}
