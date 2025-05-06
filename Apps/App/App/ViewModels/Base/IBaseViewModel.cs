namespace App.ViewModels.Base
{
    internal interface IBaseViewModel : IQueryAttributable
    {
        public INavigationService NavigationService { get; }
    }
}
