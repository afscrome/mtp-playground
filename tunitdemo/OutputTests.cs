using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace tunitdemo;

public class OutputTests
{
    [Before(Class)]
    public static void BeforeClass()
    {
        Console.Out.WriteLine("tUnit BeforeClass Console.Out");
        Console.Error.WriteLine("tUnit BeforeClass Console.Error");
        Debug.WriteLine("tUnit BeforeClass Debug");
        Trace.WriteLine("tUnit BeforeClass Trace");

        TestContext.Current?.Output.StandardOutput.WriteLine("tUnit BeforeClass Out");
    }

    [Before(Test)]
    public void BeforeTest()
    {
        Console.Out.WriteLine("tUnit BeforeTest Console.Out");
        Console.Error.WriteLine("tUnit BeforeTest Console.Error");
        Debug.WriteLine("tUnit BeforeTest Debug");
        Trace.WriteLine("tUnit BeforeTest Trace");

        TestContext.Current?.Output.StandardOutput.WriteLine("tUnit BeforeTest Out");
    }

    [Test]
    public void InstantOutput()
    {
        Console.Out.WriteLine("tUnit Test Console.Out");
        Console.Error.WriteLine("tUnit Test Console.Error");
        Debug.WriteLine("tUnit Test Debug");
        Trace.WriteLine("tUnit Test Trace");

        TestContext.Current?.Output.StandardOutput.WriteLine("tUnit Test Out");
    }

    [Test]
    [Timeout(15_000)]
    public async Task LongRunningOutput(CancellationToken ct)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Out.WriteLine($"tUnit Test Console.Out {i}");
            Console.Error.WriteLine($"tUnit Test Console.Error {i}");
            Debug.WriteLine($"tUnit Test Debug {i}");
            Trace.WriteLine($"tUnit Test Trace {i}");

            TestContext.Current?.Output.StandardOutput.WriteLine($"tUnit Test Out {i}");
            await Task.Delay(1000, ct);
        }
    }

    [After(Test)]
    public void AfterTest()
    {
        Console.Out.WriteLine("tUnit AfterTest Console.Out");
        Console.Error.WriteLine("tUnit AfterTest Console.Error");
        Debug.WriteLine("tUnit AfterTest Debug");
        Trace.WriteLine("tUnit AfterTest Trace");

        TestContext.Current?.Output.StandardOutput.WriteLine("tUnit AfterTest Out");
    }

    [After(Class)]
    public static void AfterClass()
    {
        Console.Out.WriteLine("tUnit AfterClass Console.Out");
        Console.Error.WriteLine("tUnit AfterClass Console.Error");
        Debug.WriteLine("tUnit AfterClass Debug");
        Trace.WriteLine("tUnit AfterClass Trace");

        TestContext.Current?.Output.StandardOutput.WriteLine("tUnit AfterClass Out");
    }
}
