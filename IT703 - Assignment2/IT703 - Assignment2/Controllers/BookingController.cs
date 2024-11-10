using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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
            return View();
        }

        // POST: BookingController1/Create
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
