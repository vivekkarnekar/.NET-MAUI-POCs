namespace MAUIAppSkeleton.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null);
        Task GoBackAsync(IDictionary<string, object>? routeParameters = null);
    }
}
