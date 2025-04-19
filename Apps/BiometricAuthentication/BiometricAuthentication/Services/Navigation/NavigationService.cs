namespace BiometricAuthentication.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync(IDictionary<string, object>? routeParameters = null)
        {
            return routeParameters != null
                ? Shell.Current.GoToAsync("..", routeParameters)
                : Shell.Current.GoToAsync("..");
        }

        public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, true, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation, true);
        }

        public Task NavigateToPageAsync(string route, IDictionary<string, object>? routeParameters = null)
        {
            return routeParameters != null
                ? Shell.Current.GoToAsync(route, true, routeParameters)
                : Shell.Current.GoToAsync(route, true);
        }
    }
}
