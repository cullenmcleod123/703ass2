using IT703___Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT703___Assignment2.Controllers
{
    public class ReportController : Controller
    {
        private readonly DataAccess _dataAccess;

        public ReportController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IActionResult InHouseReport()
        {
            // Get the data from the database via DataAccess
            List<InHouseReportModel> reportData = _dataAccess.GetInHouseReport();

            // Pass the data to the view
            return View(reportData);
        }

        public IActionResult EndOfDay()
        {
            PaymentSummary summary;
            var reports = _dataAccess.GetEndOfDayReport();
            // ViewBag.Summary = summary;
            return View(reports);
        }


        // GET: ReportController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
