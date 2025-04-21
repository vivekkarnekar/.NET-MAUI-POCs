using Plugin.Fingerprint;

namespace BiometricAuthentication.Extensions
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
#if IOS
            services.AddSingleton<IAuthenticationService, Platforms.AuthenticationService>();
#endif
#if ANDROID
            CrossFingerprint.SetCurrentActivityResolver(() => Platform.CurrentActivity);
            services.AddSingleton<IAuthenticationService, Platforms.AuthenticationService>();
#endif
            services.AddSingleton(CrossFingerprint.Current);
        }

        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<LoginPageViewModel>();
        }

        public static void RegisterViews(this IServiceCollection services)
        {
            services.AddTransient<HomePage>();
            services.AddTransient<LoginPage>();
        }

        public static void RegisterPopups(this IServiceCollection services)
        {
            // Register your popups here
        }
    }
}
