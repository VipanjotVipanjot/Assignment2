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
    public class usersTablesController : Controller
    {
        private DbModel db = new DbModel();

        // GET: usersTables
        public ActionResult Index()
        {
            var usersTables = db.usersTables.Include(u => u.bookTable);
            return View(usersTables.ToList());
        }

        // GET: usersTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersTable usersTable = db.usersTables.Find(id);
            if (usersTable == null)
            {
                return HttpNotFound();
            }
            return View(usersTable);
        }

        // GET: usersTables/Create
        public ActionResult Create()
        {
            ViewBag.bookId = new SelectList(db.bookTables, "bookId", "name");
            return View();
        }

        // POST: usersTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,firstName,lastName,phoneNo,email,bookId")] usersTable usersTable)
        {
            if (ModelState.IsValid)
            {
                db.usersTables.Add(usersTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookId = new SelectList(db.bookTables, "bookId", "name", usersTable.bookId);
            return View(usersTable);
        }

        // GET: usersTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersTable usersTable = db.usersTables.Find(id);
            if (usersTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookId = new SelectList(db.bookTables, "bookId", "name", usersTable.bookId);
            return View(usersTable);
        }

        // POST: usersTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,firstName,lastName,phoneNo,email,bookId")] usersTable usersTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookId = new SelectList(db.bookTables, "bookId", "name", usersTable.bookId);
            return View(usersTable);
        }

        // GET: usersTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersTable usersTable = db.usersTables.Find(id);
            if (usersTable == null)
            {
                return HttpNotFound();
            }
            return View(usersTable);
        }

        // POST: usersTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usersTable usersTable = db.usersTables.Find(id);
            db.usersTables.Remove(usersTable);
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
