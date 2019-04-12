using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService
{
    public interface IReportService
    {
        Task<IEnumerable<ReportItem>> GetReportAsync();
    }
}
