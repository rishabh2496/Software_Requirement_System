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
    public class Software_Contract_CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Software_Contract_Category
        public ActionResult Index()
        {
            var software_Contract_Categories = db.Software_Contract_Categories.Include(s => s.Software_Contract);
            return View(software_Contract_Categories.ToList());
        }

        // GET: Software_Contract_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Contract_Category software_Contract_Category = db.Software_Contract_Categories.Find(id);
            if (software_Contract_Category == null)
            {
                return HttpNotFound();
            }
            return View(software_Contract_Category);
        }

        // GET: Software_Contract_Category/Create
        public ActionResult Create()
        {
            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name");
            return View();
        }

        // POST: Software_Contract_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Software_ContractID")] Software_Contract_Category software_Contract_Category)
        {
            if (ModelState.IsValid)
            {
                db.Software_Contract_Categories.Add(software_Contract_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name", software_Contract_Category.Software_ContractID);
            return View(software_Contract_Category);
        }

        // GET: Software_Contract_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Contract_Category software_Contract_Category = db.Software_Contract_Categories.Find(id);
            if (software_Contract_Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name", software_Contract_Category.Software_ContractID);
            return View(software_Contract_Category);
        }

        // POST: Software_Contract_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Software_ContractID")] Software_Contract_Category software_Contract_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software_Contract_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name", software_Contract_Category.Software_ContractID);
            return View(software_Contract_Category);
        }

        // GET: Software_Contract_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Contract_Category software_Contract_Category = db.Software_Contract_Categories.Find(id);
            if (software_Contract_Category == null)
            {
                return HttpNotFound();
            }
            return View(software_Contract_Category);
        }

        // POST: Software_Contract_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Software_Contract_Category software_Contract_Category = db.Software_Contract_Categories.Find(id);
            db.Software_Contract_Categories.Remove(software_Contract_Category);
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
