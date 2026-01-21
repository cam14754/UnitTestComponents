
namespace UnitTestComponents.UnitTests;

class HandlersContextStub : IMauiContext
{
    public HandlersContextStub(IServiceProvider services)
    {
        Services = services;
        Handlers = Services.GetRequiredService<IMauiHandlersFactory>();
    }

    public IServiceProvider Services { get; }

    public IMauiHandlersFactory Handlers { get; }
}
