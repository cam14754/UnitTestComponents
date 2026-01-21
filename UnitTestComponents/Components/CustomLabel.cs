using SQuan.Helpers.Maui.Mvvm;

namespace UnitTestComponents;

public partial class CustomLabel : Label
{
    [BindableProperty] public partial int Num { get; set; } = 0;

    public CustomLabel()
    {
        OnNumChanged(this.Num);
    }
    partial void OnNumChanged(int value)
    {
        this.BackgroundColor = (value % 4) switch
        {
            0 => Colors.Red,
            1 => Colors.Orange,
            2 => Colors.Yellow,
            3 => Colors.Green,
            4 => Colors.Purple,
            _ => Colors.Transparent
        };
        this.Text = $"Num is {value}";
    }
}
