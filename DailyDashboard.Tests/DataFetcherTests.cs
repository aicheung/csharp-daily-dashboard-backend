namespace DailyDashboard.Tests;

public class DataFetcherTests
{
    [Fact]
    public void ShouldFetchHKAirportPassengerDataFromWebbSite()
    {
        IDailyDataFetcher fetcher = new WebbSiteDataFetcher();
        DailyDataPoint data = fetcher.FetchData();
        Assert.NotNull(data);
        Assert.NotNull(data.Id);
        Assert.NotEmpty(data.Id);
        Assert.NotNull(data.Time);
        Assert.True(DateTime.Compare(new DateTime(2023,1,1,0,0,0), data.Time) < 0);
        Assert.NotNull(data.Value);
        int passengers = int.Parse(data.Value);
        Assert.True(passengers >= int.MinValue && passengers <= int.MaxValue);
    }
}