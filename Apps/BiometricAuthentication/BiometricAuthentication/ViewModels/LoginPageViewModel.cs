using Plugin.Maui.Biometric;

namespace BiometricAuthentication.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IBiometric _biometric;

        public LoginPageViewModel(INavigationService NavigationService) : base(NavigationService)
        {
            _navigationService = NavigationService;
            _biometric = BiometricAuthenticationService.Default;
        }

        [RelayCommand]
        public async Task Login(string plugin)
        {
            if (plugin == "Biometric")
            {
                await AuthenticateWithBiometric();
            }
            else
            {
                await AuthenticateWithFingerprint();
            }
        }

        private async Task AuthenticateWithBiometric()
        {
            var enrolledTypes = await _biometric.GetEnrolledBiometricTypesAsync();

            foreach (var type in enrolledTypes)
            {
                Console.WriteLine($"Enrolled Biometric Type: {type}");
            }

            var result = await _biometric.GetAuthenticationStatusAsync();

            if (result == BiometricHwStatus.Success)
            {
                await AuthenticateUser();
            }
        }

        private async Task AuthenticateWithFingerprint()
        {
            
        }

        private async Task AuthenticateUser()
        {
            var result = await _biometric.AuthenticateAsync(new AuthenticationRequest()
            {
                Title = "Please authenticate to login",
                Subtitle = "Use your fingerprint or face ID",
                NegativeText = "Cancel",
                Description = "Authenticate to access the app",
                AllowPasswordAuth = true,
            }, CancellationToken.None);

            if (result.Status == BiometricResponseStatus.Success)
            {
                await _navigationService.NavigateToAsync("//HomePage");
            }
            else
            {
                var userInput = await AppShell.Current.DisplayAlert("Authentication Failed", "Please try again.", "OK", "Cancel");
                if (userInput)
                {
                    await AuthenticateUser();
                }
            }
        }

    }
}
