using Microsoft.AspNetCore.Mvc;
using GBC_TRAVEL.Data;
using GBC_TRAVEL.Models;

namespace GBC_TRAVEL.Controllers
{
    public class FlightController : Controller
    {
        private readonly AppDbContext _db;

        public FlightController(AppDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            var flights = _db.Flights.ToList();
            return View(flights);


        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _db.Flights.FirstOrDefault(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FlightID,Airline,Origin,Destination,DepartureTime,ArrivalTime,Price,SeatsAvailable")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _db.Flights.Add(flight);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FlightID,Airline,Origin,Destination,DepartureTime,ArrivalTime,Price,SeatsAvailable")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(flight);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }
        

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _db.Flights.FirstOrDefault(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var flight = _db.Flights.Find(id);
            if(flight != null)
            {
                _db.Flights.Remove(flight);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

    }
}
