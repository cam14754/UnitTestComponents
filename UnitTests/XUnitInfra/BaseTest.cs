
using System.Reflection;

namespace UnitTestComponents.UnitTests;

/// <summary>
/// Base test class that sets up common services and state for unit tests.
/// </summary>
[Collection("Base Test")]
public abstract class BaseTest : IDisposable, IAsyncDisposable
{
    private readonly CultureInfo defaultCulture, defaultUiCulture;
    protected ITestOutputHelper? previousOutputHelper;

    private bool isDisposed;

    private static readonly Lock InitLock = new();
    private static IServiceProvider? services;

    protected readonly MockAppInfo mockAppInfo;
    protected const AppTheme initialAppTheme = AppTheme.Light;

    /// <summary>
    /// Gets the shared service provider used by the unit test infrastructure.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the provider was not initialized properly.</exception>
    public IServiceProvider Services
    {
        get => services ?? throw new InvalidOperationException($"{nameof(BaseTest)} was not initialized correctly.");
        protected set => services = value;
    }

    /// <summary>
    /// Standard test timeouts (in milliseconds).
    /// </summary>
    // Example:
    // [Fact(Timeout = (int)TestDuration.Short)]
    // public void FastOperation_CompletesWithinTimeout()
    protected enum TestDuration
    {
#if DEBUG
        /// <summary>20 Seconds.</summary>
        Short = 20_000,
        /// <summary>50 Seconds.</summary>
        Medium = 50_000,
        /// <summary>100 Seconds.</summary>
        Long = 100_000
#else
        /// <summary>Two Seconds.</summary>
        Short = 2_000,
        /// <summary>Five Seconds.</summary>
        Medium = 5_000,
        /// <summary>Ten Seconds.</summary>
        Long = 10_000
#endif
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTest"/> class.
    /// </summary>
    /// <param name="testOutputHelper">The xUnit output helper for the current test.</param>
    protected BaseTest(ITestOutputHelper testOutputHelper)
    {
        lock (InitLock)
        {
            defaultCulture = Thread.CurrentThread.CurrentCulture;
            defaultUiCulture = Thread.CurrentThread.CurrentUICulture;

            previousOutputHelper = XunitLogger.OutputHelper;
            XunitLogger.OutputHelper = testOutputHelper;

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddProvider(new XUnitLoggerProvider());
            });

            CallInternalStaticMethod(typeof(DeviceDisplay), null, "SetCurrent");
            CallInternalStaticMethod(typeof(DeviceInfo), null, "SetCurrent");

            mockAppInfo = new MockAppInfo { RequestedTheme = initialAppTheme };
            CallInternalStaticMethod(typeof(AppInfo), mockAppInfo, "SetCurrent");

            DispatcherProvider.SetCurrent(new MockDispatcherProvider());

            CallInternalStaticMethod(typeof(DeviceDisplay), null, "SetCurrent");

            services = serviceCollection.BuildServiceProvider();
            AppServices.Services = services;
        }
    }

    /// <summary>
    /// Finalizes the instance.
    /// </summary>
    ~BaseTest() => Dispose(false);

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        Dispose(false);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Performs asynchronous cleanup for derived tests.
    /// </summary>
    /// <returns>A task representing the cleanup operation.</returns>
    protected virtual ValueTask DisposeAsyncCore() => ValueTask.CompletedTask;

    /// <summary>
    /// Restores per-test process/thread state.
    /// </summary>
    /// <param name="isDisposing">
    /// <see langword="true"/> when called from <see cref="Dispose()"/>;
    /// <see langword="false"/> when called from the finalizer.
    /// </param>
    protected virtual void Dispose(bool isDisposing)
    {
        if (isDisposed)
        {
            return;
        }

        CallInternalStaticMethod(typeof(DeviceDisplay), null, "SetCurrent");
        DispatcherProvider.SetCurrent(null);

        XunitLogger.OutputHelper = previousOutputHelper;

        Thread.CurrentThread.CurrentCulture = defaultCulture;
        Thread.CurrentThread.CurrentUICulture = defaultUiCulture;

        isDisposed = true;
    }

    /// <summary>
    /// Adds the window to the application.
    /// </summary>
    /// <param name="app"> The app to add the window to. </param>
    /// <param name="window"> The window to add. </param>
    protected static void AddWindowToApplication(Application app, Window window)
    {
        MethodInfo method = app.GetType().GetMethod("AddWindow", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) ?? throw new MissingMethodException(typeof(Application).FullName, "AddWindow");
        method.Invoke(app, [window]);
    }

    private static void CallInternalStaticMethod(Type staticType, object? value, string methodName)
    {
        MethodInfo method = staticType.GetMethod(methodName, BindingFlags.Static |
                                                             BindingFlags.NonPublic |
                                                             BindingFlags.Public)
            ?? throw new MissingMethodException(staticType.FullName, methodName);
        method.Invoke(null, [value]);
    }
}
