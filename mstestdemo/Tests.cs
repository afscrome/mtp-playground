using System.Diagnostics;

namespace mstestdemo;

[TestClass]
public class Tests
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public void PassingTest()
    {
        Assert.AreEqual(4, Add(2, 2));
    }

    [TestMethod]
    [Ignore]
    public void FailingTest()
    {
        Assert.AreEqual(5, Add(2, 2));
    }

    [TestMethod]
    [Timeout(15_000, CooperativeCancellation = true)]
    public async Task LongRunning()
    {
        var ct = TestContext.CancellationToken;
        await Task.Delay(TimeSpan.FromSeconds(10), ct);
    }

    [TestMethod]
    [Ignore]
    [Timeout(1_000, CooperativeCancellation = true)]
    public async Task Timeout()
    {
        var ct = TestContext.CancellationToken;
        await Task.Delay(TimeSpan.FromSeconds(10), ct);
    }

    [TestMethod]
    public void Output()
    {
        Console.WriteLine("MSTest Console Output");
        Debug.WriteLine("MSTest Debug Output");
        Trace.WriteLine("MSTest Trace Output");

        TestContext.WriteLine("MSTest TestContext Output");

        TestContext.DisplayMessage(MessageLevel.Error, "MSTest TestContext Error Message");
        TestContext.DisplayMessage(MessageLevel.Warning, "MSTest TestContext Warning Message");
        TestContext.DisplayMessage(MessageLevel.Informational, "MSTest TestContext Informational Message");
    }


    int Add(int x, int y)
    {
        return x + y;
    }
}