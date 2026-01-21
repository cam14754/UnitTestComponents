

namespace UnitTestComponents.UnitTests;

/// <summary>
/// Minimal <see cref="IDispatcher"/> implementation for unit tests.
/// </summary>
public sealed class MockDispatcher : IDispatcher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MockDispatcher"/> class.
    /// </summary>
    public MockDispatcher() => ManagedThreadId = Environment.CurrentManagedThreadId;

    /// <inheritdoc />
    public bool IsDispatchRequired => false;

    /// <inheritdoc />
    public int ManagedThreadId { get; }

    /// <inheritdoc />
    public IDispatcherTimer CreateTimer() => new DispatcherTimerStub(this);

    /// <inheritdoc />
    public bool Dispatch(Action action)
    {
        action();
        return true;
    }

    /// <inheritdoc />
    public bool DispatchDelayed(TimeSpan delay, Action action)
    {
        Thread.Sleep(delay);
        action();
        return true;
    }

    sealed class DispatcherTimerStub : IDispatcherTimer, IDisposable
    {
        readonly IDispatcher dispatcher;

        Timer? timer;

        public DispatcherTimerStub(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public TimeSpan Interval { get; set; }

        public bool IsRepeating { get; set; }

        public bool IsRunning => timer != null;

        public event EventHandler? Tick;

        public void Start()
        {
            timer = new Timer(OnTimeout, null, Interval, IsRepeating ? Interval : Timeout.InfiniteTimeSpan);

            void OnTimeout(object? state)
            {
                dispatcher.Dispatch(() => Tick?.Invoke(this, EventArgs.Empty));
            }
        }

        public void Stop() => Dispose();

        public void Dispose()
        {
            timer?.Dispose();
            timer = null;
        }
    }
}
