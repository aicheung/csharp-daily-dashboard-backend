using System.Globalization;

namespace DailyDashboard.Data;

public class HomeOfficeBoatArrivalsDataFetcher : IDailyDataFetcher
{
    private string url = "https://www.gov.uk/government/publications/migrants-detected-crossing-the-english-channel-in-small-boats/migrants-detected-crossing-the-english-channel-in-small-boats-last-7-days";
    private string valueXPath = @"//*[@id=""contents""]/div[1]/div[3]/div/div/div/table/tbody/tr[7]/td[1]";
    private string dateXPath = @"//*[@id=""contents""]/div[1]/div[3]/div/div/div/table/tbody/tr[7]/th";
    private string dataId = "homeOfficeBoatArrivalsCount";

    public override DailyDataPoint FetchData()
    {
        var doc = this.GetHtmlDocument(url);

        var valueNode = doc.DocumentNode.SelectSingleNode(valueXPath);
        var dateNode = doc.DocumentNode.SelectSingleNode(dateXPath);

        return new DailyDataPoint
        {
            Id = dataId,
            Time = DateTime.ParseExact(dateNode?.InnerText, "dd MMMM yyyy", CultureInfo.InvariantCulture),
            Value = int.Parse(valueNode?.InnerText, NumberStyles.AllowThousands, CultureInfo.InvariantCulture)
        };
    }
}