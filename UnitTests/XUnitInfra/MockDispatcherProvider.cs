

namespace UnitTestComponents.UnitTests;

/// <summary>
/// Test <see cref="IDispatcherProvider"/> implementation that returns a stable dispatcher per thread.
/// </summary>
/// <remarks>
/// Inspired by .NET MAUI unit test stubs.
/// </remarks>
sealed class MockDispatcherProvider : IDispatcherProvider, IDisposable
{
    static readonly MockDispatcher dispatcherMock = new();

    readonly ThreadLocal<IDispatcher> dispatcherInstance = new(() => dispatcherMock);

    /// <inheritdoc />
    public IDispatcher GetForCurrentThread() => dispatcherInstance.Value ?? throw new InvalidOperationException();

    void IDisposable.Dispose() => dispatcherInstance.Dispose();
}
