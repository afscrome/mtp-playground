using System.Diagnostics;

namespace mstestdemo;

// Lifecycle docs: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-writing-tests-lifecycle
[TestClass]
public class OutputLifecycleTests
{
    public TestContext TestContext { get; set; }

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        Console.Out.WriteLine("MSTest ClassInitialize Console.Out");
        Console.Error.WriteLine("MSTest ClassInitialize Console.Error");
        Debug.WriteLine("MSTest ClassInitialize Debug");
        Trace.WriteLine("MSTest ClassInitialize Trace");

        context.WriteLine("MSTest ClassInitialize TestContext.WriteLine");
    }

    [TestInitialize]
    public void TestInitialize()
    {
        Console.Out.WriteLine("MSTest TestInitialize Console.Out");
        Console.Error.WriteLine("MSTest TestInitialize Console.Error");
        Debug.WriteLine("MSTest TestInitialize Debug");
        Trace.WriteLine("MSTest TestInitialize Trace");

        TestContext.WriteLine("MSTest TestInitialize TestContext.WriteLine");
    }

    [TestMethod]
    public void InstantOutput()
    {
        Console.Out.WriteLine("MSTest Test Console.Out");
        Console.Error.WriteLine("MSTest Test Console.Error");
        Debug.WriteLine("MSTest Test Debug");
        Trace.WriteLine("MSTest Test Trace");

        TestContext.WriteLine("MSTest Test Out");
    }

    [TestMethod]
    [Timeout(15_000, CooperativeCancellation = true)]
    public async Task LongRunningOutput()
    {
        var ct = TestContext.CancellationToken;
        for (int i = 0; i < 10; i++)
        {
            Console.Out.WriteLine($"MSTest Test Console.Out {i}");
            Console.Error.WriteLine($"MSTest Test Console.Error {i}");
            Debug.WriteLine($"MSTest Test Debug {i}");
            Trace.WriteLine($"MSTest Test Trace {i}");

            TestContext.WriteLine($"MSTest Test WriteLine {i}");
            await Task.Delay(1000, ct);
        }
    }

    [TestCleanup]
    public void TestCleanup()
    {
        Console.Out.WriteLine("MSTest TestCleanup Console.Out");
        Console.Error.WriteLine("MSTest TestCleanup Console.Error");
        Debug.WriteLine("MSTest TestCleanup Debug");
        Trace.WriteLine("MSTest TestCleanup Trace");

        TestContext.WriteLine("TestCleanup TearDown WriteLine");
    }

    [ClassCleanup]
    public static void ClassCleanup(TestContext context)
    {
        Console.Out.WriteLine("MSTest ClassCleanup Console.Out");
        Console.Error.WriteLine("MSTest ClassCleanup Console.Error");
        Debug.WriteLine("MSTest ClassCleanup Debug");
        Trace.WriteLine("MSTest ClassCleanup Trace");

        context.WriteLine("MSTest ClassCleanup Out");
    }
}
