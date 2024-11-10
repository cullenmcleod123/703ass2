using _702assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace _702assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataAccess _dataAccess = new DataAccess();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Bookings()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }

        public ActionResult AddCustomer(FormCollection form)
        {
            try
            {
                string firstName = form["FirstName"];
                string lastName = form["LastName"];
                string email = form["Email"];
                string phoneNumber = form["PhoneNumber"];
                string address = form["Address"];
                int? companyId = string.IsNullOrEmpty(form["CompanyID"]) ? (int?)null : int.Parse(form["CompanyID"]);
                int travelAgencyId = int.Parse(form["TravelAgencyID"]);

                _dataAccess.AddCustomer(firstName, lastName, email, phoneNumber, address, companyId, travelAgencyId);

                return RedirectToAction("CustomerList");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
