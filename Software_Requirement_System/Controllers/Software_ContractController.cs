using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Software_Requirement_System.Models;

namespace Software_Requirement_System.Controllers
{
    public class Software_ContractController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Software_Contract
        public ActionResult Index()
        {
            return View(db.Software_Contracts.ToList());
        }

        // GET: Software_Contract/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Contract software_Contract = db.Software_Contracts.Find(id);
            if (software_Contract == null)
            {
                return HttpNotFound();
            }
            return View(software_Contract);
        }

        // GET: Software_Contract/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Software_Contract/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,FromDate,ToDate,OptionYears")] Software_Contract software_Contract)
        {
            if (ModelState.IsValid)
            {
                db.Software_Contracts.Add(software_Contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(software_Contract);
        }

        // GET: Software_Contract/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Contract software_Contract = db.Software_Contracts.Find(id);
            if (software_Contract == null)
            {
                return HttpNotFound();
            }
            return View(software_Contract);
        }

        // POST: Software_Contract/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,FromDate,ToDate,OptionYears")] Software_Contract software_Contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software_Contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(software_Contract);
        }

        // GET: Software_Contract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Contract software_Contract = db.Software_Contracts.Find(id);
            if (software_Contract == null)
            {
                return HttpNotFound();
            }
            return View(software_Contract);
        }

        // POST: Software_Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Software_Contract software_Contract = db.Software_Contracts.Find(id);
            db.Software_Contracts.Remove(software_Contract);
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
