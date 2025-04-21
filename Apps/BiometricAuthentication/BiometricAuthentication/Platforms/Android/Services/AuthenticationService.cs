using AndroidX.Biometric;
using AndroidX.Core.Content;

namespace BiometricAuthentication.Platforms
{
    public class AuthenticationService : IAuthenticationService
    {
        public TaskCompletionSource<bool>? _tcs;

        public Task<bool> AuthenticateAsync(string reason)
        {
            _tcs = new TaskCompletionSource<bool>();

            var executor = ContextCompat.GetMainExecutor(Android.App.Application.Context);
            var currentActivity = Platform.CurrentActivity;

            if (currentActivity == null)
            {
                _tcs.TrySetResult(false);
                return _tcs.Task;
            }

            var biometricPrompt = new BiometricPrompt((AndroidX.Fragment.App.FragmentActivity)currentActivity, executor,
                new AuthenticationCallbackImpl(_tcs));

            var promptInfo = new BiometricPrompt.PromptInfo.Builder()
                .SetTitle("Please authenticate to login")
                .SetSubtitle(reason)
                .SetNegativeButtonText("Cancel")
                .Build();

            biometricPrompt.Authenticate(promptInfo);

            return _tcs.Task;
        }

        private class AuthenticationCallbackImpl : BiometricPrompt.AuthenticationCallback
        {
            private readonly TaskCompletionSource<bool> _tcs;

            public AuthenticationCallbackImpl(TaskCompletionSource<bool> tcs)
            {
                _tcs = tcs;
            }

            public override void OnAuthenticationSucceeded(BiometricPrompt.AuthenticationResult result)
            {
                _tcs.TrySetResult(true);
            }

            public override void OnAuthenticationFailed()
            {
                _tcs.TrySetResult(false);
            }

            public override void OnAuthenticationError(int errorCode, Java.Lang.ICharSequence errString)
            {
                _tcs.TrySetResult(false);
            }
        }
    }
}
