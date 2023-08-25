namespace DailyDashboard.Data;

using System.Globalization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

public class JobsDBDataFetcher: IDailyDataFetcher
{
    private string url = "https://hk.jobsdb.com/hk/job-list/information-technology/software-development/1";
    private string valueXPath = @"//*[@id=""jobList""]/div/div[1]/div[1]/div/span";
    private string dataId = "jobsDBSoftwareDeveloperCount";

    public override DailyDataPoint FetchData() 
    {
        var doc = this.GetHtmlDocument(url);

        var valueNode = doc.DocumentNode.SelectSingleNode(valueXPath);

        return new DailyDataPoint
        {
            Id = dataId,
            Time = DateTime.Now,
            Value = ExtractNumberOfJobs(valueNode?.InnerText)
        };
    }

    private static int ExtractNumberOfJobs(string input)
    {
        // Use regex to extract the number with comma
        Match match = Regex.Match(input, @"(\d{1,3}(,\d{3})*)(?= jobs)");

        if (match.Success)
        {
            string jobCountString = match.Value.Replace(",", "");
            return Int32.Parse(jobCountString, NumberStyles.AllowThousands);
        }

        return 0; // or throw an exception or handle the error in another appropriate way
    }
}