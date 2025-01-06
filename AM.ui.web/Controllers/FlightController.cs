using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {

        private readonly IServiceFlight _flightService;
        private readonly IServicePlane _planeService;
        public FlightController(IServiceFlight flightService, IServicePlane planeService)
        {
            _flightService = flightService;
            _planeService = planeService;
        }
        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(_flightService.GetAll().ToList());
            else
                return
                View(_flightService.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
        }
        //Sort
        public ActionResult Sort()
        {
            return View("Index", _flightService.SortFlights());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View("Details", _flightService.GetById(id));
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(),
                "PlaneId", "PlaneId");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    flight.Pilot = PilotImage.FileName;
                }
                _flightService.Add(flight);
                _flightService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_flightService.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flight flight, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    flight.Pilot = PilotImage.FileName;
                }
                _flightService.Update(flight);
                _flightService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_flightService.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public ActionResult Delete(Flight flight)
         {
             try
             {

                 _flightService.Delete(flight);
                 _flightService.Commit();
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }*/



        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Récupération de l'entité à partir de l'id
                var flight = _flightService.GetById(id);

                if (flight == null)
                {
                    // Si l'entité n'existe pas, rediriger vers une erreur ou une page adaptée
                    return NotFound();
                }

                // Suppression de l'entité
                _flightService.Delete(flight);
                _flightService.Commit();

                // Rediriger vers la liste des entités après suppression
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Gérer les erreurs (par exemple, en les journalisant)
                ModelState.AddModelError("", "Une erreur s'est produite lors de la suppression.");
                return View();
            }
        }
    }
}
