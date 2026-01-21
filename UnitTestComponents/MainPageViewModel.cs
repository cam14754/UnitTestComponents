using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UnitTestComponents;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] public partial int Num { get; set; } = 0;

    [RelayCommand]
    public void IncrementNum()
    {
        Num++;
    }

    [RelayCommand]
    public void DecrementNum()
    {
        Num--;
    }

    [RelayCommand]
    public void SetNum(int value)
    {
        Num = value;
    }
}
