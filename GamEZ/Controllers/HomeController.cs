using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamEZ.Models;

namespace GamEZ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (GamEZDbEntities db = new GamEZDbEntities())
            {
                return View(db.Games.ToList());
            }
        }

        public ActionResult About()
        {
            using (GamEZDbEntities db = new GamEZDbEntities())
            {
                ViewBag.img = db.Games.OrderByDescending(a => a.NumberOfDownload)
                    .Select(x => x.Image).FirstOrDefault();

                ViewBag.Topimg = db.Games.OrderByDescending(a => a.NumberOfDownload)
                    .Select(x => x.Image).Take(3).ToList();

                return View(db.Information.FirstOrDefault());
            }
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact con)
        {
            using (GamEZDbEntities db = new GamEZDbEntities())
            {
                if (ModelState.IsValid)
                {
                    con.Date = DateTime.Now.ToShortDateString();
                    con.Opened = "Not Opened";
                    db.Contacts.Add(con);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(con);
            }
                
        }
    }
}