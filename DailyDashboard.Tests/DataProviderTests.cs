namespace DailyDashboard.Tests;

public class DataProviderTests
{
    [Fact]
    public void ShouldFetchData()
    {
        var fetcherMock = new Mock<IDailyDataFetcher>();
        DailyDataPoint dp = new DailyDataPoint();
        dp.Id = "WebbSite";
        dp.Value = "111";
        fetcherMock.Setup(p => p.FetchData()).Returns(dp);

        IDailyDataProvider provider = new WebbSiteDataProvider(fetcherMock.Object);
        Assert.Equal(provider.FetchData(), dp);
    }
}