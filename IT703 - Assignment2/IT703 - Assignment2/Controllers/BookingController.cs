using IT703___Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace IT703___Assignment2.Controllers
{

    public class BookingController : Controller
    {
        private readonly DataAccess _dataAccess;


        public BookingController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;

        }
        // GET: BookingController1
        public ActionResult Index()
        {
            var bookings = _dataAccess.GetAllBookings();
            return View(bookings);
        }

        // GET: BookingController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController1/Create
        public ActionResult Create()
        {
            // Fetch available rooms and car parks
            var rooms = _dataAccess.GetAvailableRooms();  // Method to fetch available rooms
            var carParks = _dataAccess.GetAvailableCarParks();  // Method to fetch available car parks

            // Populate the dropdown lists
            ViewBag.Rooms = new SelectList(rooms, "RoomID");
            ViewBag.CarParks = new SelectList(carParks, "CarParkID");

            return View();
        }

        // POST: Booking/CreateBooking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingModel booking)
        {
            if (ModelState.IsValid)
            {
                // Add the booking via the DataAccess layer
                _dataAccess.AddBooking(booking.CustomerID, booking.RoomID, booking.CarParkID, booking.DateBooked, booking.LeavingDate, booking.BookingStatus);

                // Redirect to another page after successful booking creation (e.g., show booking list or confirmation)
                return RedirectToAction("BookingConfirmation");  // Adjust as necessary
            }

            // If model state is not valid, fetch rooms and car parks again
            var rooms = _dataAccess.GetAvailableRooms();
            var carParks = _dataAccess.GetAvailableCarParks();
            var customers = _dataAccess.GetCustomers();
            ViewBag.CustomerID = new SelectList(customers, "CustomerID");
            ViewBag.Rooms = new SelectList(rooms, "RoomID");
            ViewBag.CarParks = new SelectList(carParks, "CarParkID");

            return View(booking);  // Re-display the form with validation errors
        }
            // GET: BookingController1/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController1/Edit/5
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

        // GET: BookingController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController1/Delete/5
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
