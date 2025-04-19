namespace MAUIAppSkeleton
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoute();
        }

        private static void RegisterRoute()
        {
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
