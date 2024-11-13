using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FIAP_PROJETO_CSHARP.Models;
using FIAP_PROJETO_CSHARP.Data;

namespace FIAP_PROJETO_CSHARP.Controllers
{
    [Authorize]
    public class TruckController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TruckController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var trucks = _context.Trucks.ToList();
            return View(trucks);
        }

        public IActionResult Details(long id)
        {
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Truck truck)
        {
            if (ModelState.IsValid)
            {
                _context.Trucks.Add(truck);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        public IActionResult Edit(long id)
        {
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, Truck truck)
        {
            if (id != truck.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Trucks.Update(truck);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        public IActionResult Delete(long id)
        {
            var truck = _context.Trucks.Find(id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var truck = _context.Trucks.Find(id);
            _context.Trucks.Remove(truck);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
