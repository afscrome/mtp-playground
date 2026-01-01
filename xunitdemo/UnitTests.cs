namespace xunitdemo;

public class UnitTest1
{
    [Fact]
    public void PassingTest()
    {
        var ct = TestContext.Current.CancellationToken;
        Assert.Equal(4, Add(2, 2));
    }

    [Fact(Timeout = 15000)]
    public async Task LongRunningTest()
    {
        var token = TestContext.Current.CancellationToken;
        await Task.Delay(TimeSpan.FromSeconds(10), token);
    }

    [Fact(Explicit = true)]
    public void FailingTest()
    {
        Assert.Equal(5, Add(2, 2));
    }

    int Add(int x, int y)
    {
        return x + y;
    }
}