using HixAPI.Services;

namespace HixAPI.Tests;

public class APIServiceTests {

    [Fact]
    public void DiscordServiceRunsWithoutException() {
        var ds = new DiscordService();
        ds.StartAsync(CancellationToken.None);

        // If the execution reaches here without throwing an exception, the test passes
        Assert.True(true);
    }

    [Fact]
    public void MetricServiceRunsWithoutException() {
        var ms = new MetricService();
        ms.StartAsync(CancellationToken.None);

        // If the execution reaches here without throwing an exception, the test passes
        Assert.True(true);
    }
}