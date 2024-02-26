using Microsoft.AspNetCore.Mvc;
using GBC_TRAVEL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GBC_TRAVEL.Data;

namespace GBC_TRAVEL.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly AppDbContext _db;

        public CarRentalController(AppDbContext db)
        {
            _db = db;
        }


        // GET: CarRental
        public IActionResult Index()
        {
            var carRentals = _db.CarRentals.ToList();
            return View(carRentals);
        }

        // GET: CarRental/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = _db.CarRentals.FirstOrDefault(m => m.CarRentalID == id);
            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        // GET: CarRental/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarRental/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CarRentalID,CompanyName,Location,CarType,PricePerDay,PickupDate,DropoffDate")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                _db.Add(carRental);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        // GET: CarRental/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = _db.CarRentals.Find(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }

        // POST: CarRental/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CarRentalID,CompanyName,Location,CarType,PricePerDay,PickupDate,DropoffDate")] CarRental carRental)
        {
            if (id != carRental.CarRentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(carRental);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRentalExists(carRental.CarRentalID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        // GET: CarRental/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = _db.CarRentals.FirstOrDefault(m => m.CarRentalID == id);
            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        // POST: CarRental/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var carRental = _db.CarRentals.Find(id);
            _db.CarRentals.Remove(carRental);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CarRentalExists(int id)
        {
            return _db.CarRentals.Any(e => e.CarRentalID == id);
        }
    }
}