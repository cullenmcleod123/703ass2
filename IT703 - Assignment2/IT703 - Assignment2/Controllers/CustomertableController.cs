using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using IT703___Assignment2.Models;

namespace IT703___Assignment2.Controllers
{
    public class CustomertableController : Controller
    {
        private readonly DataAccess _dataAccess;


        public CustomertableController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;

        }

        public ActionResult Index()
        {
            var customers = _dataAccess.GetAllCustomers();
            return View(customers);
        }

        // GET: Customertable/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customertable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customertable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customermodel customer)
        {
            if (ModelState.IsValid) // Ensure model validation
            {
                try
                {
                    // Call AddCustomer method to insert data into the database
                    _dataAccess.AddCustomer(
                        customer.FirstName,
                        customer.LastName,
                        customer.Email,
                        customer.PhoneNumber,
                        customer.Address,
                        customer.CompanyID,
                        customer.TravelAgencyID
                    );

                    // After successful insertion, redirect to the Index action
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., database errors)
                    ModelState.AddModelError("", "An error occurred while adding the customer.");
                }
            }

            // If validation failed, return the view with the model to show validation errors
            return View(customer);
        }

        // GET: Customertable/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customertable/Edit/5
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

        // GET: Customertable/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customertable/Delete/5
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
