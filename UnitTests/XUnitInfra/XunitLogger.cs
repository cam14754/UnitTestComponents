

namespace UnitTestComponents.UnitTests;

/// <summary>
/// An <see cref="ILogger"/> implementation that writes log output to xUnit via
/// <see cref="ITestOutputHelper"/>.
/// </summary>
public class XunitLogger : ILogger
{
    string categoryName { get; } = string.Empty;

    /// <summary>
    /// Gets or sets the output helper that receives log lines.
    /// </summary>
    /// <remarks>
    /// This is process-wide state; test infrastructure is expected to set and restore it per test.
    /// </remarks>
    public static ITestOutputHelper? OutputHelper { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="XunitLogger"/> class.
    /// </summary>
    /// <param name="categoryName">Logger category name.</param>
    public XunitLogger(string categoryName)
    {
        this.categoryName = categoryName;
    }

    /// <inheritdoc />
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        OutputHelper?.WriteLine($"{categoryName}: {logLevel}: {formatter(state, exception)}");
    }

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel) => true;

    /// <inheritdoc />
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        throw new NotImplementedException();
    }
}
