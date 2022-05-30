using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamEZ.Models;

namespace Wuzzef.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class InformationController : Controller
    {

        //private ApplicationDbContext db = new ApplicationDbContext();

        private GamEZDbEntities db = new GamEZDbEntities();
        // GET: Information
        public ActionResult Index()
        {
            return View(db.Information.ToList());
        }

        // GET: Information/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Information info)
        {
            if (ModelState.IsValid)
            {
                db.Information.Add(info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(info);
        }

        // GET: Information/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Information/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Information/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Information/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
