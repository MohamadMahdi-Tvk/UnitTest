using UnitTest.ConsoleApp;
using UnitTest.ConsoleApp.TestData;
using Xunit.Abstractions;

namespace UnitTest.Test;

public class MathHelperTest
{
    private readonly ITestOutputHelper _outputHelper; // => For Log

    public MathHelperTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    //[Fact] => for method without parameters
    //public void SumTest()
    //{
    //    MathHelper mathHelper = new MathHelper();

    //    int x = 4;
    //    int y = 2;

    //    var result = mathHelper.Sum(x, y);

    //    //Test 1:
    //    Assert.Equal(6, result);

    //    //Test 2:
    //    Assert.IsType<int>(result);
    //}

    //[Fact(Skip ="برای بحث آموزش این رو غیرفعال کردم")]
    //[Theory] // => for method with parameters
    [Theory(Skip = "برای بحث آموزش این رو غیرفعال کردم")] // => Skip: If we dont want to execute the test method
    [InlineData(5, 5, 10)]
    [InlineData(-5, -5, -10)]
    [InlineData(1000, 5000, 6000)]
    [Trait("Service", "Cart")] // => For Test Category
    public void SumTest(int x, int y, int expected)
    {
        MathHelper mathHelper = new MathHelper();

        var result = mathHelper.Sum(x, y);

        Assert.Equal(expected, result);

        Assert.IsType<int>(result);
    }

    [Theory]
    [MemberData(nameof(DataForTest.GetData), MemberType = typeof(DataForTest))] // => GetData from the other source
    [Trait("Service", "Order")]
    public void Sum_MemberData_Test(int x, int y, int expected)
    {
        MathHelper mathHelper = new MathHelper();

        var result = mathHelper.Sum(x, y);

        Assert.Equal(expected, result);

        Assert.IsType<int>(result);
    }

    [Theory]
    [ClassData(typeof(MemberClassData))] // => GetData from the other source (better way)
    [Trait("Endpoint", "Order")] 
    public void Sum_ClassData_Test(int x, int y, int expected)
    {
        MathHelper mathHelper = new MathHelper();

        var result = mathHelper.Sum(x, y);

        _outputHelper.WriteLine("this is a test");
        _outputHelper.WriteLine(x.ToString());

        Assert.Equal(expected, result);

        Assert.IsType<int>(result);
    }
}
