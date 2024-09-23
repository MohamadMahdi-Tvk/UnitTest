namespace UnitTest.ConsoleApp.TestData;

public static class DataForTest
{
    public static List<object[]> GetData()
    {
        List<object[]> myData = new List<object[]>();

        myData.Add(new object[] { 5, 5, 10 });
        myData.Add(new object[] { 20, 10, 30 });

        return myData;
    }
}
