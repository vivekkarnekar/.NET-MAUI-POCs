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
            await _navigationService.NavigateToAsync($"//Login");
        }
    }
}
