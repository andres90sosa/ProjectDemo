using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectDemo.Models;

namespace ProjectDemo.Controllers
{
    [Authorize]
    public class VideoJuegosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /VideoJuegos/
        public ActionResult Index()
        {
            var videojuegos = db.VideoJuegos.Include(v => v.Genero);
            return View(videojuegos.ToList());
        }

        // GET: /VideoJuegos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuego videojuego = db.VideoJuegos.Find(id);
            if (videojuego == null)
            {
                return HttpNotFound();
            }
            return View(videojuego);
        }

        // GET: /VideoJuegos/Create
        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(db.Generos, "Id", "Nombre");
            return View();
        }

        // POST: /VideoJuegos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Descripcion,ImagenUrl,GeneroId")] VideoJuego videojuego)
        {
            if (ModelState.IsValid)
            {
                db.VideoJuegos.Add(videojuego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(db.Generos, "Id", "Nombre", videojuego.GeneroId);
            return View(videojuego);
        }

        // GET: /VideoJuegos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuego videojuego = db.VideoJuegos.Find(id);
            if (videojuego == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "Id", "Nombre", videojuego.GeneroId);
            return View(videojuego);
        }

        // POST: /VideoJuegos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Descripcion,ImagenUrl,GeneroId")] VideoJuego videojuego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videojuego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "Id", "Nombre", videojuego.GeneroId);
            return View(videojuego);
        }

        // GET: /VideoJuegos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuego videojuego = db.VideoJuegos.Find(id);
            if (videojuego == null)
            {
                return HttpNotFound();
            }
            return View(videojuego);
        }

        // POST: /VideoJuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoJuego videojuego = db.VideoJuegos.Find(id);
            db.VideoJuegos.Remove(videojuego);
            db.SaveChanges();
            return RedirectToAction("Index");
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
