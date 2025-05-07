namespace PushNotifications.Locator
{
    internal static class ServiceLocator
    {
        private static IServiceProvider? _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetService<T>() where T : class
        {
            if (_serviceProvider == null)
            {
                throw new InvalidOperationException("ServiceLocator is not initialized. Call Initialize() method first.");
            }
            return _serviceProvider.GetService(typeof(T)) as T ?? throw new InvalidOperationException($"Service of type {typeof(T).Name} not registered.");
        }
    }
}
