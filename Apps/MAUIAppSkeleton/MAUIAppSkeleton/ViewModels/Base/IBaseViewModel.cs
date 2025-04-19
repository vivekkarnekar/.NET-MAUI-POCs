using MAUIAppSkeleton.Services.Navigation;

namespace MAUIAppSkeleton.ViewModels.Base
{
    internal interface IBaseViewModel : IQueryAttributable
    {
        public INavigationService NavigationService { get; }
    }
}
