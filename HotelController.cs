using GBC_TRAVEL.Data;
using GBC_TRAVEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GBC_TRAVEL.Controllers
{
    public class HotelController : Controller
    {
        private readonly AppDbContext _db;

        public HotelController(AppDbContext context)
        {
            _db = context;
        }

        // GET: Hotels
        public IActionResult Index()
        {

            var flights = _db.Hotels.ToList();
            return View(flights);
        }

        // GET: Hotels/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = _db.Hotels.FirstOrDefault(m => m.HotelID == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HotelID,Name,Location,Rating,NumberOfRooms,PricePerNight")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _db.Add(hotel);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = _db.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("HotelID,Name,Location,Rating,NumberOfRooms,PricePerNight")] Hotel hotel)
        {
            if (id != hotel.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(hotel);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelID))
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
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = _db.Hotels.FirstOrDefault(m => m.HotelID == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hotel = _db.Hotels.Find(id);
            if(hotel != null)
            {
                _db.Hotels.Remove(hotel);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
            

        private bool HotelExists(int id)
        {
            return _db.Hotels.Any(e => e.HotelID == id);
        }
    }  
}
