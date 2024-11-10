using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT703___Assignment2.Controllers
{
    public class CarParkController : Controller
    {
        private readonly DataAccess _dataAccess;

        // Constructor to inject DataAccess
        public CarParkController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: CarPark/Index
        public ActionResult Index()
        {
            var carParks = _dataAccess.GetAllCarParks(); // Retrieve all car parks
            return View(carParks); // Return the list of car parks to the view
        }

        // GET: CarParkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarParkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarParkController/Create
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

        // GET: CarParkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarParkController/Edit/5
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

        // GET: CarParkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarParkController/Delete/5
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
