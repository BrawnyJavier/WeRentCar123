using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ReportService
{
    public class ReportService : IReportService
    {
        private string _url;
        public ReportService(string url)
        {
            _url = url;

        }
        public async Task<IEnumerable<ReportItem>> GetReportAsync()
        {
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            var _res = await request.GetResponseAsync();

            using (HttpWebResponse response = (HttpWebResponse)(_res))
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                html = await reader.ReadToEndAsync();

            var Result = JsonConvert.DeserializeObject<List<ReportItem>>(html);

            return Result;
        }
    }
}
