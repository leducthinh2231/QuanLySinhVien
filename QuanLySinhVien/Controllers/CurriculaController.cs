using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Controllers
{
    public class CurriculaController : Controller
    {
        private AttendanceDBEntities db = new AttendanceDBEntities();

        // GET: Curricula
        public ActionResult Index()
        {
            return View(db.Curriculums.ToList());
        }

        // GET: Curricula/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculums.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // GET: Curricula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrID,CurrName")] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                db.Curriculums.Add(curriculum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curriculum);
        }

        // GET: Curricula/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculums.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // POST: Curricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrID,CurrName")] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curriculum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curriculum);
        }

        // GET: Curricula/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculums.Find(id);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // POST: Curricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Curriculum curriculum = db.Curriculums.Find(id);
            db.Curriculums.Remove(curriculum);
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
