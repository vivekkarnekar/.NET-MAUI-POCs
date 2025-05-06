namespace App.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..", true);
        }

        public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, true, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation, true);
        }
    }
}
