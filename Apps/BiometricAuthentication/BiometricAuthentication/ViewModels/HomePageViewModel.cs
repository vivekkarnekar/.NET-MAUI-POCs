namespace BiometricAuthentication.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        [RelayCommand]
        public async Task Logout()
        {
            await NavigationService.NavigateToAsync($"//Login");
        }
    }
}
