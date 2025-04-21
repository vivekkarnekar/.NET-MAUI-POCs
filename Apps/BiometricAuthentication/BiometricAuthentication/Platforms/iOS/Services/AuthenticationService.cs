using LocalAuthentication;

namespace BiometricAuthentication.Platforms
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> AuthenticateAsync(string reason)
        {
            var context = new LAContext();
            var canEvaluate = context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out var error);

            if (canEvaluate)
            {
                var result = await context.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, reason);
                return result.Item1;
            }

            return false;
        }
    }
}
