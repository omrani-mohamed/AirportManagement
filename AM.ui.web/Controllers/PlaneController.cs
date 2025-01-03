﻿using AM.Application.Core.Domain;
using AM.Application.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.ui.web.Controllers
{
    public class PlaneController : Controller
    {
        IServicePlane _planeService;
        public PlaneController(IServicePlane planeService)
        {
            _planeService = planeService;
        }
        // GET: PlaneController
        public ActionResult Index()
        {
            return View(_planeService.GetAll().ToList());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            return View(_planeService.GetById(id));
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane plane)
        {
            try
            {
                _planeService.Add(plane);
                _planeService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlaneController/Edit/5
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

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlaneController/Delete/5
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
