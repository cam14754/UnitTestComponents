
namespace UnitTestComponents.UnitTests;

public class LabelTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
    // Base test works fine also, able to instantiate basic maui controls
    [Fact]
    public void Label_DefaultValues_AreCorrect()
    {
        // Arrange
        var label = new CustomLabel();
        // Assert
        Assert.NotNull(label);
        Assert.Equal(0, label.Num);
    }

    // Controls inheriting from label work also
    [Fact]
    public void LabelColorTest()
    {
        var label = new CustomLabel();

        label.Num = 1;

        Assert.Equal(1, label.Num);
        Assert.Equal(Colors.Orange, label.BackgroundColor);
    }
}
