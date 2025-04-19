namespace MAUIAppSkeleton.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync(IDictionary<string, object>? routeParameters = null) => Shell.Current.GoToAsync("..", routeParameters);

        public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, true, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation, true);
        }
    }
}
