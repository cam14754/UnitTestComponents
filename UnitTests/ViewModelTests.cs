using UnitTestComponents;
using UnitTestComponents.UnitTests;

namespace UnitTests;

public class ViewModelTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
    // More base test useage
    [Fact]
    public void TestDefaults()
    {
        MainPageViewModel vm = new MainPageViewModel();

        Assert.NotNull(vm);

        Assert.Equal(0, vm.Num);
    }

    [Fact]
    public void TestIncrementCommand()
    {
        MainPageViewModel vm = new MainPageViewModel();
        Assert.NotNull(vm);
        Assert.Equal(0, vm.Num);
        vm.IncrementNum();
        Assert.Equal(1, vm.Num);
        vm.IncrementNum();
        Assert.Equal(2, vm.Num);
        vm.IncrementNum();
        Assert.Equal(3, vm.Num);
    }

    [Fact]
    public void TestDecrementCommand()
    {
        MainPageViewModel vm = new MainPageViewModel();
        Assert.NotNull(vm);
        Assert.Equal(0, vm.Num);
        vm.DecrementNum();
        Assert.Equal(-1, vm.Num);
        vm.DecrementNum();
        Assert.Equal(-2, vm.Num);
        vm.DecrementNum();
        Assert.Equal(-3, vm.Num);
    }
}
