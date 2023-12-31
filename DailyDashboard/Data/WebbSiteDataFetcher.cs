namespace DailyDashboard.Data;

using System.Globalization;
using HtmlAgilityPack;

public class WebbSiteDataFetcher: IDailyDataFetcher
{
    private string url = "https://webb-site.com/dbpub/hkpax.asp?t=1&p=1&f=0";
    private string valueXPath = "//body/div[4]/table/tr[2]/td[4]";
    private string dateXPath = "//body/div[4]/table/tr[2]/td[1]";
    private string dataId = "webbSiteDailyHKResidentAirportPassengerCount";

    public override DailyDataPoint FetchData() 
    {
        var doc = this.GetHtmlDocument(url);

        var valueNode = doc.DocumentNode.SelectSingleNode(valueXPath);
        var dateNode = doc.DocumentNode.SelectSingleNode(dateXPath);

        return new DailyDataPoint
        {
            Id = dataId,
            Time = DateTime.Parse(dateNode?.InnerText),
            Value = int.Parse(valueNode?.InnerText, NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture)
        };
    }
}