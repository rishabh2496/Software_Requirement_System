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
    public class Software_Task_OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Software_Task_Order
        public ActionResult Index()
        {
            var software_Task_Orders = db.Software_Task_Orders.Include(s => s.Software_Contract);
            return View(software_Task_Orders.ToList());
        }

        // GET: Software_Task_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Task_Order software_Task_Order = db.Software_Task_Orders.Find(id);
            if (software_Task_Order == null)
            {
                return HttpNotFound();
            }
            return View(software_Task_Order);
        }

        // GET: Software_Task_Order/Create
        public ActionResult Create()
        {
            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name");
            return View();
        }

        // POST: Software_Task_Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Software_ContractID,Code")] Software_Task_Order software_Task_Order)
        {
            if (ModelState.IsValid)
            {
                db.Software_Task_Orders.Add(software_Task_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name", software_Task_Order.Software_ContractID);
            return View(software_Task_Order);
        }

        // GET: Software_Task_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Task_Order software_Task_Order = db.Software_Task_Orders.Find(id);
            if (software_Task_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name", software_Task_Order.Software_ContractID);
            return View(software_Task_Order);
        }

        // POST: Software_Task_Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Software_ContractID,Code")] Software_Task_Order software_Task_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software_Task_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Software_ContractID = new SelectList(db.Software_Contracts, "ID", "Name", software_Task_Order.Software_ContractID);
            return View(software_Task_Order);
        }

        // GET: Software_Task_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Task_Order software_Task_Order = db.Software_Task_Orders.Find(id);
            if (software_Task_Order == null)
            {
                return HttpNotFound();
            }
            return View(software_Task_Order);
        }

        // POST: Software_Task_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Software_Task_Order software_Task_Order = db.Software_Task_Orders.Find(id);
            db.Software_Task_Orders.Remove(software_Task_Order);
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
