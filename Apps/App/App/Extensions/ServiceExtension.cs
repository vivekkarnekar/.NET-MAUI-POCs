namespace App.Extensions
{
    internal static class ServiceExtensions
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            // register other services here
        }

        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HomePageViewModel>();
        }

        public static void RegisterViews(this IServiceCollection services)
        {
            services.AddTransient<HomePage>();
            services.AddTransient<MainPage>();
        }

        public static void RegisterPopups(this IServiceCollection services)
        {
            // Register your popups here
        }
    }
}
