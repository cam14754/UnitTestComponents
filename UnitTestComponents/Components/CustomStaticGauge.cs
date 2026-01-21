using SQuan.Helpers.Maui.Mvvm;
using Telerik.Maui.Controls;
using Telerik.Maui.Controls.Gauges;

namespace UnitTestComponents;

public partial class CustomStaticGauge : RadRadialGauge
{
    [BindableProperty] public partial double Num { get; set; } = 0;
    [BindableProperty] public partial bool Invert { get; set; } = false;

    public GaugeNeedleIndicator Indicator = new();

    public CustomStaticGauge()
    {
        Margin = new Thickness(0, -10, 0, -40);

        GaugeLinearAxis axis = new()
        {
            Maximum = 100,
            Minimum = 0,
            Step = 10,
            Stroke = GetTextColor(),
            TextColor = GetTextColor()
        };

        this.Axis = axis;

        this.Ranges = CreateRanges();

        GaugeNeedleIndicator indicator = new()
        {
            Offset = 0,
        };

        this.Indicators.Add(indicator);
        this.Indicator = indicator;

        Loaded += (_, __) => Update();
    }

    partial void OnNumChanged(double value) => Update();

    private void Update()
    {
        if (Invert)
        {
            Indicator.Value = 1.0 - Num;
        }
        else
        {
            Indicator.Value = Num;
        }
    }

    private static GaugeRangesDefinition CreateRanges()
    {
        var gradient = new GaugeGradientRange
        {
            From = 0,
            To = 100
        };

        gradient.GradientStops.Add(new RadGradientStop { Offset = 99.05, Color = Colors.Green });
        gradient.GradientStops.Add(new RadGradientStop { Offset = 95, Color = Colors.GreenYellow });
        gradient.GradientStops.Add(new RadGradientStop { Offset = 90, Color = Colors.Yellow });
        gradient.GradientStops.Add(new RadGradientStop { Offset = 60, Color = Colors.Orange });
        gradient.GradientStops.Add(new RadGradientStop { Offset = 50, Color = Colors.Red });
        gradient.GradientStops.Add(new RadGradientStop { Offset = 0, Color = Colors.Red });

        var ranges = new GaugeRangesDefinition();
        ranges.Ranges.Add(gradient);
        return ranges;
    }

    private static Color GetTextColor()
    {
        if (Application.Current?.Resources.TryGetValue("TextColor", out var value) == true &&
            value is Color c)
        {
            return c;
        }

        return Colors.Gray;
    }
}