using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.CloudMessaging;

#if ANDROID
using Plugin.Firebase.Core.Platforms.Android;
#endif
#if IOS
using Plugin.Firebase.Core.Platforms.iOS;
#endif

namespace PushNotifications
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .RegisterFirebaseServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.RegisterAppServices();
            builder.Services.RegisterServices();
            builder.Services.RegisterViewModels();
            builder.Services.RegisterViews();
            builder.Services.RegisterPopups();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events => {
#if IOS
            events.AddiOS(iOS => iOS.WillFinishLaunching((app, launchOptions) => 
            {
                CrossFirebase.Initialize();
                FirebaseCloudMessagingImplementation.Initialize();
                return false;
            }));
#elif ANDROID
            events.AddAndroid(android => android.OnCreate((activity, _) => CrossFirebase.Initialize(activity)));
#endif
            });

            return builder;
        }
    }
}
