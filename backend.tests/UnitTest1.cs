namespace backend.tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }

    [Theory]
    [InlineData("foo", 2)]
    [InlineData("bar", 5)]
    public void TestTheory1(string stringInput, int numberInput)
    {

    }
}