using System.Diagnostics;

using Xunit.Runner.Common;
using Xunit.Sdk;

// See https://xunit.net/docs/capturing-output
[assembly: CaptureConsole]
[assembly: CaptureTrace]

namespace xunitdemo;

public sealed class OutputLifecycleTests : IClassFixture<OutputLifecycleTests.OutputLifecycleFixture>, IDisposable
{
    private readonly ITestOutputHelper _outputHelper;
    public OutputLifecycleTests(OutputLifecycleFixture _, ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;

        Console.Out.WriteLine("xUnit Test.ctor Console.Out");
        Console.Error.WriteLine("xUnit Test.ctor Console.Error");
        Debug.WriteLine("xUnit Test.ctor Debug");
        Trace.WriteLine("xUnit Test.ctor Trace");

        _outputHelper.WriteLine("xUnit Test.ctor TestOutputHelper");
    }

    [Fact]
    public void AllOutput()
    {
        Console.Out.WriteLine("xUnit Test Console.Out");
        Console.Error.WriteLine("xUnit Test Console.Error");
        Debug.WriteLine("xUnit Test Debug");
        Trace.WriteLine("xUnit Test Trace");

        _outputHelper.WriteLine("xUnit Test TestOutputHelper");
    }

    [Fact(Timeout = 15000)]
    public async Task LongRunning()
    {
        var ct = TestContext.Current.CancellationToken;
        for (int i = 0; i < 10; i++)
        {
            Console.Out.WriteLine($"xUnit Test Console.Out {i}");
            Console.Error.WriteLine($"xUnit Test Console.Error {i}");
            Debug.WriteLine($"xUnit Test Debug {i}");
            Trace.WriteLine($"xUnit Test Trace {i}");

            _outputHelper.WriteLine($"xUnit Test TestOutputHelper {i}");
            await Task.Delay(1000, ct);
        }
    }

    public void Dispose()
    {
        Console.Out.WriteLine("xUnit Test.Dispose Console.Out");
        Console.Error.WriteLine("xUnit Test.Dispose Console.Error");
        Debug.WriteLine("xUnit Test.Dispose Debug");
        Trace.WriteLine("xUnit Test.Dispose Trace");

        _outputHelper.WriteLine("xUnit Test.Dispose TestOutputHelper");
    }

    public class OutputLifecycleFixture : IDisposable
    {
        private readonly IMessageSink _messageSink;

        public OutputLifecycleFixture(IMessageSink messageSink)
        {
            _messageSink = messageSink;

            Console.Out.WriteLine("xUnit Fixture.ctor Console.Out");
            Console.Error.WriteLine("xUnit Fixture.ctor Console.Error");
            Debug.WriteLine("xUnit Fixture.ctor Debug");
            Trace.WriteLine("xUnit Fixture.ctor Trace");

            TestContext.Current.TestOutputHelper?.WriteLine("xUnit Fixture.ctor TestOutputHelper");
            _messageSink.OnMessage(new DiagnosticMessage("xUnit Fixture.ctor DiagnosticMessage"));
        }

        public void Dispose()
        {
            Console.Out.WriteLine("xUnit Fixture.Dispose Console.Out");
            Console.Error.WriteLine("xUnit Fixture.Dispose Console.Error");
            Debug.WriteLine("xUnit Fixture.Dispose Debug");
            Trace.WriteLine("xUnit Fixture.Dispose Trace");

            TestContext.Current.TestOutputHelper?.WriteLine("xUnit Fixture.Dispose TestOutputHelper");
            _messageSink?.OnMessage(new DiagnosticMessage("xUnit Fixture.Dispose DiagnosticMessage"));
        }
    }

}

