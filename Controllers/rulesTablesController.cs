﻿using System;
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
    public class rulesTablesController : Controller
    {
        private DbModel db = new DbModel();

        // GET: rulesTables
        public ActionResult Index()
        {
            return View(db.rulesTables.ToList());
        }

        // GET: rulesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rulesTable rulesTable = db.rulesTables.Find(id);
            if (rulesTable == null)
            {
                return HttpNotFound();
            }
            return View(rulesTable);
        }

        // GET: rulesTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rulesTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ruleId,name,description,inactionFrom,penalty")] rulesTable rulesTable)
        {
            if (ModelState.IsValid)
            {
                db.rulesTables.Add(rulesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rulesTable);
        }

        // GET: rulesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rulesTable rulesTable = db.rulesTables.Find(id);
            if (rulesTable == null)
            {
                return HttpNotFound();
            }
            return View(rulesTable);
        }

        // POST: rulesTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ruleId,name,description,inactionFrom,penalty")] rulesTable rulesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rulesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rulesTable);
        }

        // GET: rulesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rulesTable rulesTable = db.rulesTables.Find(id);
            if (rulesTable == null)
            {
                return HttpNotFound();
            }
            return View(rulesTable);
        }

        // POST: rulesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rulesTable rulesTable = db.rulesTables.Find(id);
            db.rulesTables.Remove(rulesTable);
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
