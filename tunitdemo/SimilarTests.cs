
using System.Diagnostics;

public class UnitTests
{
    [Test]
    public void Output()
    {
        Console.WriteLine("tUnit Console Output");
        Debug.WriteLine("tUnit Debug Output");
        Trace.WriteLine("tUnit Trace Output");

        TestContext.Current?.Output.ErrorOutput.WriteLine("tUnit Error Output");
        TestContext.Current?.Output.StandardOutput.WriteLine("tUnit Output Writer");
    }
}