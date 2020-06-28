using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2Library.Models;

namespace Assignment2Library.Controllers
{
    public class publisherTablesController : Controller
    {
        private DbModel db = new DbModel();

        // GET: publisherTables
        public ActionResult Index()
        {
            return View(db.publisherTables.ToList());
        }

        // GET: publisherTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publisherTable publisherTable = db.publisherTables.Find(id);
            if (publisherTable == null)
            {
                return HttpNotFound();
            }
            return View(publisherTable);
        }

        // GET: publisherTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: publisherTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "publisherId,name,country,international,paperQuality")] publisherTable publisherTable)
        {
            if (ModelState.IsValid)
            {
                db.publisherTables.Add(publisherTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publisherTable);
        }

        // GET: publisherTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publisherTable publisherTable = db.publisherTables.Find(id);
            if (publisherTable == null)
            {
                return HttpNotFound();
            }
            return View(publisherTable);
        }

        // POST: publisherTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "publisherId,name,country,international,paperQuality")] publisherTable publisherTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisherTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisherTable);
        }

        // GET: publisherTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publisherTable publisherTable = db.publisherTables.Find(id);
            if (publisherTable == null)
            {
                return HttpNotFound();
            }
            return View(publisherTable);
        }

        // POST: publisherTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            publisherTable publisherTable = db.publisherTables.Find(id);
            db.publisherTables.Remove(publisherTable);
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
