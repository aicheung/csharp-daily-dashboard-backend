namespace DailyDashboard.Tests;

public class DataManagerTests
{
    [Fact]
    public void ShouldAllowRegisterFromProviders()
    {
        DailyDataManager mgr = new DailyDataManager();
        var providerMock = new Mock<IDailyDataProvider>();
        IDailyDataProvider pv = providerMock.Object;
        mgr.Register(pv);
        Assert.NotEmpty(mgr.Providers);
    }

    [Fact]
    public void ShouldGetDataFromProviders()
    {
        DailyDataManager mgr = new DailyDataManager();
        var fetcherMock = new Mock<IDailyDataFetcher>();
        DailyDataPoint dp = new DailyDataPoint();
        dp.Id = "WebbSite";
        dp.Value = "111";
        fetcherMock.Setup(p => p.FetchData()).Returns(dp);
        var providerMock = new WebbSiteDataProvider(fetcherMock.Object);
        IDailyDataProvider pv = providerMock;
        mgr.Register(pv);
        
        List<DailyDataPoint> latestData = mgr.GetData();
        Assert.NotEmpty(latestData);
        Assert.Equal("111", latestData[0].Value);
    }
}