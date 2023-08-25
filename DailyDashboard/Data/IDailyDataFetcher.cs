using HtmlAgilityPack;

namespace DailyDashboard.Data;

public abstract class IDailyDataFetcher
{
    public abstract DailyDataPoint FetchData();

    protected HtmlDocument GetHtmlDocument(string url) {
        var web = new HtmlWeb();
        web.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36";
        var doc = web.Load(url);
        return doc;
    }
}