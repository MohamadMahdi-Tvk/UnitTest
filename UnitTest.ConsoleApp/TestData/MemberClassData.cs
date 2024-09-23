using System.Collections;

namespace UnitTest.ConsoleApp.TestData;

public class MemberClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 8, 3, 11 };
        yield return new object[] { 10, 10, 20 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

