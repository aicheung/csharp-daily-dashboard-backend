using System.Globalization;

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
        int passengers = data.Value;
        Assert.True(passengers >= int.MinValue && passengers <= int.MaxValue);
    }

    [Fact]
    public void ShouldFetchDeveloperJobCountsFromJobsDB()
    {
        IDailyDataFetcher fetcher = new JobsDBDataFetcher();
        DailyDataPoint data = fetcher.FetchData();
        Assert.NotNull(data);
        Assert.NotNull(data.Id);
        Assert.NotEmpty(data.Id);
        Assert.NotNull(data.Time);
        Assert.True(DateTime.Compare(new DateTime(2023,1,1,0,0,0), data.Time) < 0);
        Assert.NotNull(data.Value);
        int jobs = data.Value;
        Assert.True(jobs > 0 && jobs <= int.MaxValue);
    }

    [Fact]
    public void ShouldFetchHomeOfficeBoatArrivals()
    {
        IDailyDataFetcher fetcher = new HomeOfficeBoatArrivalsDataFetcher();
        DailyDataPoint data = fetcher.FetchData();
        Assert.NotNull(data);
        Assert.NotNull(data.Id);
        Assert.NotEmpty(data.Id);
        Assert.NotNull(data.Time);
        //Home Office should have data by now
        Assert.True(DateTime.Compare(DateTime.Now.AddDays(-2.0), data.Time) < 0);
        Assert.NotNull(data.Value);
        int arrivals = data.Value;
        Assert.True(arrivals >= 0 && arrivals <= int.MaxValue);
    }
}