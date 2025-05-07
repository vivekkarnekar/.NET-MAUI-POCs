namespace PushNotifications
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Current is not null) Current.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}