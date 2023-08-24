namespace DailyDashboard.Data;

public class WebbSiteDataProvider: IDailyDataProvider
{
    public WebbSiteDataProvider(IDailyDataFetcher fetcher): base(fetcher)
    {
        
    }
}