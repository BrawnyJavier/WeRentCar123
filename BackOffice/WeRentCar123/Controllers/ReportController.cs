using Microsoft.AspNetCore.Mvc;
using ReportService;
using System.Threading.Tasks;
namespace WeRentCar123.Controllers
{
    public class ReportController : Controller
    {
        private IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        // GET: Report
        public async Task<ActionResult> Index()
        {
            var res = await _reportService.GetReportAsync();

            return View(res);
        }

      
    }
}