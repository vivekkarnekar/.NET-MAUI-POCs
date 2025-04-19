using Plugin.Fingerprint.Abstractions;
using Plugin.Maui.Biometric;

namespace BiometricAuthentication.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IBiometric _biometric;
        private readonly IFingerprint _fingerprint;

        public LoginPageViewModel(INavigationService NavigationService, IFingerprint fingerprint) : base(NavigationService)
        {
            _navigationService = NavigationService;
            _biometric = BiometricAuthenticationService.Default;
            _fingerprint = fingerprint;
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
            
            var isAvailable = await _fingerprint.IsAvailableAsync();

            if (isAvailable)
            {
                var request = new AuthenticationRequestConfiguration("Please authenticate to login", "Use your fingerprint or face ID")
                {
                    FallbackTitle = "Use Passcode",
                    CancelTitle = "Cancel",
                    AllowAlternativeAuthentication = true
                };

                var result = await _fingerprint.AuthenticateAsync(request);

                if (result.Authenticated)
                {
                    await _navigationService.NavigateToAsync("//HomePage");
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Authentication Failed", "Please try again.", "OK");
                }
            }
        }

        private async Task AuthenticateUser()
        {
            var result = await _biometric.AuthenticateAsync(new AuthenticationRequest()
            {
                Title = "Please authenticate to login",
                Subtitle = "Use your fingerprint or face ID",
                NegativeText = "Cancel",
                AllowPasswordAuth = true,
            }, CancellationToken.None);

            if (result.Status == BiometricResponseStatus.Success)
            {
                await _navigationService.NavigateToAsync("//HomePage");
            }
            else
            {
                await AppShell.Current.DisplayAlert("Authentication Failed", "Please try again.", "OK");
            }
        }

    }
}
