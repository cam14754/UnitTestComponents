using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System.Reflection;
using Telerik.Maui.Controls;
using Telerik.Maui.Controls.Compatibility;

namespace UnitTestComponents.UnitTests;

public abstract class BaseViewTest : BaseTest
{
    protected BaseViewTest(ITestOutputHelper testOutput) : base(testOutput)
    {
        InitializeServicesAndSetMockApplication(out var serviceProvider);
        this.Services = serviceProvider;
    }

    protected static TElementHandler CreateElementHandler<TElementHandler>(IElement view, bool doesRequireMauiContext = true)
        where TElementHandler : IElementHandler, new()
    {
        var mockElementHandler = new TElementHandler();
        mockElementHandler.SetVirtualView(view);

        if (doesRequireMauiContext)
        {
            mockElementHandler.SetMauiContext(Application.Current?.Handler?.MauiContext ?? throw new NullReferenceException());
        }

        return mockElementHandler;
    }

    protected static TViewHandler CreateViewHandler<TViewHandler>(IView view, bool doesRequireMauiContext = true)
        where TViewHandler : IViewHandler, new()
    {
        var mockViewHandler = new TViewHandler();
        mockViewHandler.SetVirtualView(view);

        if (doesRequireMauiContext)
        {
            mockViewHandler.SetMauiContext(Application.Current?.Handler?.MauiContext ?? throw new NullReferenceException());
        }

        return mockViewHandler;
    }

    static void InitializeServicesAndSetMockApplication(out IServiceProvider serviceProvider)
    {
        // I suspect something needs to be added here to allow telerik to be instantiate in a net10.0 framework

#pragma warning disable CA1416 // Validate platform compatibility
        var appBuilder = MauiApp.CreateBuilder()
            .UseSkiaSharp()
            .UseMauiApp<MockApplication>()
            .UseTelerikControls()
            .UseTelerik()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
#pragma warning restore CA1416 // Validate platform compatibility



        var mauiApp = appBuilder.Build();
        serviceProvider = mauiApp.Services;

        var shell = new Shell();
        shell.Items.Add(new ContentPage());

        var application = (MockApplication)mauiApp.Services.GetRequiredService<IApplication>();

        Type type = typeof(MockApplication);
        var method = type.GetMethod("AddWindow", BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new MissingMethodException(type.FullName, "AddWindow");

        method.Invoke(application, new object[] { new Window { Page = shell } });

        IPlatformApplication.Current = application;

        application.Handler = new ApplicationHandlerStub();
        application.Handler.SetMauiContext(new HandlersContextStub(serviceProvider));

        CreateViewHandler<MockPageHandler>(shell);
    }
}
