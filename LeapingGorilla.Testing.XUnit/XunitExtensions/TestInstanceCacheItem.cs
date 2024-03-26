namespace LeapingGorilla.Testing.XUnit.XunitExtensions
{
    /// <summary>
    /// Stores a test class instance proxy and its associated interceptor so
    /// that both can be accessed together.
    /// <see cref="LeapingGorillaAsyncLifetimeInterceptor"/> for further information
    /// on why the proxy and interceptors are required.
    /// </summary>
    internal struct TestInstanceCacheItem
    {
        public LeapingGorillaAsyncLifetimeInterceptor Interceptor { get; set; }
        public object Proxy { get; set; }
    }
}