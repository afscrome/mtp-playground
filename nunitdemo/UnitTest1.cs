using System.Diagnostics;
using System.Threading.Tasks;

using NUnit.Framework.Constraints;

namespace nunitdemo;

public class Tests
{
    [Test]
    public void Passing()
    {
        Assert.Pass();
    }

    [Test]
    [CancelAfter(15_000)]
    public async Task LongRunning()
    {
        var ct = TestContext.CurrentContext.CancellationToken;
        await Task.Delay(TimeSpan.FromSeconds(10), ct);

        Assert.Pass();
    }



    [Test]
    [Explicit]
    public void Failing1()
    {
        Assert.Fail("This is a failure");
    }

}