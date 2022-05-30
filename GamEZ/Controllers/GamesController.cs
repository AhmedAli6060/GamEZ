using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using GamEZ.Models;

namespace Wuzzef.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class GamesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private GamEZDbEntities db = new GamEZDbEntities();

        // GET: Games
        
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Category);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName), "CategoryID", "CategoryName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game game, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images/Upload"), upload.FileName);
                upload.SaveAs(path);
                game.Image = upload.FileName;
                game.Date = DateTime.Now.ToString();
                game.Status = "New";
                game.NumberOfDownload = 0;
                db.Games.Add(game);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName), "CategoryID", "CategoryName", game.categoryid);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName), "CategoryID", "CategoryName", game.categoryid);
            ViewBag.Status = new SelectList(db.Games.Select(a => a.Status).Distinct(),game.Status);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game game, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/images/Upload"), game.Image);
                if (upload != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/images/Upload"), upload.FileName);
                    upload.SaveAs(path);
                    game.Image = upload.FileName;
                }
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName), "CategoryID", "CategoryName", game.categoryid);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public ActionResult IndexView()
        {
            return View(db.Games.ToList());
        }

        [AllowAnonymous]
        public ActionResult Single(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if(game == null)
            {
                return HttpNotFound();
            }
            ViewBag.catName = db.Categories.Select(x => x.CategoryName).ToList();
            return View(game);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Single(Game game)
        {
            if (ModelState.IsValid)
            {
                var FileVirtualPath = "~/images/Upload/" + game.Image;
                
                game.NumberOfDownload = game.NumberOfDownload + 1;
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
                //return RedirectToAction("IndexView");
            }
            return View(game);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
