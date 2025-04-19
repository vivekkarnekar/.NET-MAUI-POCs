using BiometricAuthentication.Services.Navigation;

namespace BiometricAuthentication.ViewModels.Base
{
    internal interface IBaseViewModel : IQueryAttributable
    {
        public INavigationService NavigationService { get; }
    }
}
