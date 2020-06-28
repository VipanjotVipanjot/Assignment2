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
    public class bookTablesController : Controller
    {
        private DbModel db = new DbModel();

        // GET: bookTables
        public ActionResult Index()
        {
            var bookTables = db.bookTables.Include(b => b.authorTable).Include(b => b.publisherTable);
            return View(bookTables.ToList());
        }

        // GET: bookTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTable bookTable = db.bookTables.Find(id);
            if (bookTable == null)
            {
                return HttpNotFound();
            }
            return View(bookTable);
        }

        // GET: bookTables/Create
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.authorTables, "authorId", "firstName");
            ViewBag.publisherId = new SelectList(db.publisherTables, "publisherId", "name");
            return View();
        }

        // POST: bookTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookId,name,genre,readType,publishDate,authorId,publisherId")] bookTable bookTable)
        {
            if (ModelState.IsValid)
            {
                db.bookTables.Add(bookTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.authorTables, "authorId", "firstName", bookTable.authorId);
            ViewBag.publisherId = new SelectList(db.publisherTables, "publisherId", "name", bookTable.publisherId);
            return View(bookTable);
        }

        // GET: bookTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTable bookTable = db.bookTables.Find(id);
            if (bookTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.authorTables, "authorId", "firstName", bookTable.authorId);
            ViewBag.publisherId = new SelectList(db.publisherTables, "publisherId", "name", bookTable.publisherId);
            return View(bookTable);
        }

        // POST: bookTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookId,name,genre,readType,publishDate,authorId,publisherId")] bookTable bookTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.authorTables, "authorId", "firstName", bookTable.authorId);
            ViewBag.publisherId = new SelectList(db.publisherTables, "publisherId", "name", bookTable.publisherId);
            return View(bookTable);
        }

        // GET: bookTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookTable bookTable = db.bookTables.Find(id);
            if (bookTable == null)
            {
                return HttpNotFound();
            }
            return View(bookTable);
        }

        // POST: bookTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookTable bookTable = db.bookTables.Find(id);
            db.bookTables.Remove(bookTable);
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
