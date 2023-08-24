namespace DailyDashboard.Data;
public abstract class IDailyDataProvider 
{

    private IDailyDataFetcher _fetcher;

    public IDailyDataFetcher Fetcher
    {
        get
        {
            return _fetcher;
        }
    }

    public IDailyDataProvider(IDailyDataFetcher fetcher)
    {
        _fetcher = fetcher;
    }

    public IDailyDataProvider()
    {
        
    }

    public DailyDataPoint FetchData()
    {
        return _fetcher.FetchData();
    }
}
