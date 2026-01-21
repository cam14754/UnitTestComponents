

namespace UnitTestComponents.UnitTests;

/// <summary>
/// An <see cref="ILoggerProvider"/> that creates <see cref="XunitLogger"/> instances.
/// </summary>
public partial class XUnitLoggerProvider : ILoggerProvider
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XUnitLoggerProvider"/> class.
    /// </summary>
    public XUnitLoggerProvider()
    {
    }

    /// <inheritdoc />
    /// <param name="categoryName">The logger category name.</param>
    public ILogger CreateLogger(string categoryName) => new XunitLogger(categoryName);

    /// <inheritdoc />
    public void Dispose() => Dispose(true);

    /// <summary>
    /// Disposes provider resources.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> when disposing managed resources; otherwise, <see langword="false"/>.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
    }
}
