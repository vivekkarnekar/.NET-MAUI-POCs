namespace BiometricAuthentication.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public async Task Logout()
        {
            var userInput = await AppShell.Current.DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");
            if (userInput)
            {
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }
    }
}
