namespace PushNotifications.ViewModels.Base
{
    public class BaseViewModel : ObservableObject, IBaseViewModel
    {
        public INavigationService NavigationService { get; }

        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
        }
    }
}
