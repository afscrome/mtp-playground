using System.Diagnostics;

public class OutputTests
{
    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        Console.Out.WriteLine("NUnit OneTimeSetUp Console.Out");
        Console.Error.WriteLine("NUnit OneTimeSetUp Console.Error");
        Debug.WriteLine("NUnit OneTimeSetUp Debug");
        Trace.WriteLine("NUnit OneTimeSetUp Trace");

        TestContext.Progress.Write("NUnit OneTimeSetUp Progress");
        TestContext.Out.WriteLine("NUnit OneTimeSetUp Out");
        TestContext.Error.WriteLine("NUnit OneTimeSetUp Error");
    }

    [SetUp]
    public void SetUp()
    {
        Console.Out.WriteLine("NUnit Setup Console.Out");
        Console.Error.WriteLine("NUnit Setup Console.Error");
        Debug.WriteLine("NUnit Setup Debug");
        Trace.WriteLine("NUnit Setup Trace");

        TestContext.Progress.Write("NUnit Setup Progress");
        TestContext.Out.WriteLine("NUnit Setup Out");
        TestContext.Error.WriteLine("NUnit Setup Error");
    }

    [Test]
    public void InstantOutput()
    {
        Console.Out.WriteLine("NUnit Test Console.Out");
        Console.Error.WriteLine("NUnit Test Console.Error");
        Debug.WriteLine("NUnit Test Debug");
        Trace.WriteLine("NUnit Test Trace");

        TestContext.Progress.Write("NUnit Test Progress");
        TestContext.Out.WriteLine("NUnit Test Out");
        TestContext.Error.WriteLine("NUnit Test Error");
        Assert.Pass();
    }

    [Test]
    [CancelAfter(15_000)]
    public async Task LongRunningOutput(CancellationToken ct)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Out.WriteLine($"NUnit Test Console.Out {i}");
            Console.Error.WriteLine($"NUnit Test Console.Error {i}");
            Debug.WriteLine($"NUnit Test Debug {i}");
            Trace.WriteLine($"NUnit Test Trace {i}");

            TestContext.Progress.Write($"NUnit Test Progress {i}");
            TestContext.Out.WriteLine($"NUnit Test Out {i}");
            TestContext.Error.WriteLine($"NUnit Test Error {i}");
            await Task.Delay(1000, ct);
        }
    }

    [TearDown]
    public void TearDown()
    {
        Console.Out.WriteLine("NUnit TearDown Console.Out");
        Console.Error.WriteLine("NUnit TearDown Console.Error");
        Debug.WriteLine("NUnit TearDown Debug");
        Trace.WriteLine("NUnit TearDown Trace");

        TestContext.Progress.Write("NUnit TearDown Progress");
        TestContext.Out.WriteLine("NUnit TearDown Out");
        TestContext.Error.WriteLine("NUnit TearDown Error");
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
        Console.Out.WriteLine("NUnit OneTimeTearDown Console.Out");
        Console.Error.WriteLine("NUnit OneTimeTearDown Console.Error");
        Debug.WriteLine("NUnit OneTimeTearDown Debug");
        Trace.WriteLine("NUnit OneTimeTearDown Trace");

        TestContext.Progress.Write("NUnit OneTimeTearDown Progress");
        TestContext.Out.WriteLine("NUnit OneTimeTearDown Out");
        TestContext.Error.WriteLine("NUnit OneTimeTearDown Error");
    }
}