using Plugin.Fingerprint.Abstractions;
using Plugin.Maui.Biometric;

namespace BiometricAuthentication.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly IBiometric _biometric;
        private readonly IFingerprint _fingerprint;
        private readonly IAuthenticationService _authenticationService;

        public LoginPageViewModel(INavigationService navigationService, IFingerprint fingerprint, IAuthenticationService authenticationService) : base(navigationService)
        {
            _biometric = BiometricAuthenticationService.Default;
            _fingerprint = fingerprint;
            _authenticationService = authenticationService;
        }

        [RelayCommand]
        public async Task Login(string plugin)
        {
            if (plugin == "Biometric")
            {
                await AuthenticateWithBiometric();
            }
            else if (plugin == "Fingerprint")
            {
                await AuthenticateWithFingerprint();
            }
            else
            {
                await AuthenticateUsingNativeAPIs();
            }
        }

        private async Task AuthenticateWithBiometric()
        {
            var enrolledTypes = await _biometric.GetEnrolledBiometricTypesAsync();

            foreach (var type in enrolledTypes)
            {
                Console.WriteLine($"Enrolled Biometric Type: {type}");
            }

            var result = await _biometric.GetAuthenticationStatusAsync(authStrength: AuthenticatorStrength.Strong);

            if (result == BiometricHwStatus.Success)
            {
                var auth = await _biometric.AuthenticateAsync(new AuthenticationRequest()
                {
                    Title = "Please authenticate to login",
                    Subtitle = "Use your fingerprint or face ID",
                    NegativeText = "Cancel",
                    AuthStrength = AuthenticatorStrength.Strong,
                    AllowPasswordAuth = true,
                }, CancellationToken.None);

                await NavigateToHomePage(auth.Status == BiometricResponseStatus.Success);
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

                await NavigateToHomePage(result.Authenticated);
            }
        }

        private async Task AuthenticateUsingNativeAPIs()
        {
            bool isAuthenticated = await _authenticationService.AuthenticateAsync("Use your fingerprint or face ID");
            await NavigateToHomePage(isAuthenticated);
        }

        private async Task NavigateToHomePage(bool isAuthSuccess)
        {
            if (isAuthSuccess)
            {
                await NavigationService.NavigateToAsync("//HomePage");
            }
            else
            {
                await AppShell.Current.DisplayAlert("Authentication Failed", "Please try again.", "OK");
            }
        }
    }
}
