

namespace DailyDashboard.Data;
public class DailyDataManager 
{
    private List<IDailyDataProvider> _providers;

    public List<IDailyDataProvider> Providers 
    {
        get 
        {
            return _providers;
        }
    }

    public DailyDataManager() 
    {
        _providers = new List<IDailyDataProvider>();
    }

    public void Register(IDailyDataProvider provider) 
    {
        _providers.Add(provider);
    }

    public List<DailyDataPoint> GetData()
    {
        List<DailyDataPoint> result = new List<DailyDataPoint>();

        foreach(IDailyDataProvider provider in _providers)
        {
            result.Add(provider.FetchData());
        }
        return result;
    }
}
