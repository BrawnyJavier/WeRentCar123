using Microsoft.AspNetCore.Mvc;
using ReportService;
using System;
using System.Linq;
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

            return View();
        }


        public async Task<IActionResult> GetReport(DateTime? Date = null)
        {
            var res = await _reportService.GetReportAsync();

            if (Date != null)
            {
                var filteredResult = res.Where(d => d.date.Date == Date.Value.Date).ToList();

                return Ok(filteredResult);
            }

            return Ok(res);
        }

    }
}