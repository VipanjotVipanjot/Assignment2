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
    public class authorTablesController : Controller
    {
        private DbModel db = new DbModel();

        // GET: authorTables
        public ActionResult Index()
        {
            return View(db.authorTables.ToList());
        }

        // GET: authorTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authorTable authorTable = db.authorTables.Find(id);
            if (authorTable == null)
            {
                return HttpNotFound();
            }
            return View(authorTable);
        }

        // GET: authorTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: authorTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "authorId,firstName,lastName,age,country")] authorTable authorTable)
        {
            if (ModelState.IsValid)
            {
                db.authorTables.Add(authorTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorTable);
        }

        // GET: authorTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authorTable authorTable = db.authorTables.Find(id);
            if (authorTable == null)
            {
                return HttpNotFound();
            }
            return View(authorTable);
        }

        // POST: authorTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "authorId,firstName,lastName,age,country")] authorTable authorTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorTable);
        }

        // GET: authorTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authorTable authorTable = db.authorTables.Find(id);
            if (authorTable == null)
            {
                return HttpNotFound();
            }
            return View(authorTable);
        }

        // POST: authorTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            authorTable authorTable = db.authorTables.Find(id);
            db.authorTables.Remove(authorTable);
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
