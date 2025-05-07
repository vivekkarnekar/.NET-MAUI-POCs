using Plugin.Firebase.CloudMessaging;

namespace PushNotifications.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        [RelayCommand]
        public async Task Notify()
        {
            await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();

            Console.WriteLine($"FCM token: {token}");
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = token,
                Title = "Firebase Token"
            });
        }
    }
}
