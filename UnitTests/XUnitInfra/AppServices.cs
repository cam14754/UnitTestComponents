namespace UnitTestComponents.UnitTests;

/// <summary>
/// Simple access point for an <see cref="IServiceProvider"/> used by unit test infrastructure.
/// </summary>
public static class AppServices
{
    /// <summary>
    /// Gets or sets the current service provider.
    /// </summary>
    /// <remarks>
    /// Under unit tests, this is typically assigned by <see cref="BaseTest"/>.
    /// </remarks>
    public static IServiceProvider? Services { get; set; } = IPlatformApplication.Current?.Services;

    /// <summary>
    /// Gets a service of type <typeparamref name="T"/> from <see cref="Services"/>.
    /// </summary>
    /// <typeparam name="T">Service type.</typeparam>
    /// <returns>The resolved service, or <see langword="null"/> if not registered.</returns>
    public static T? GetService<T>() => Services is IServiceProvider sp ? sp.GetService<T>() : default;
}
