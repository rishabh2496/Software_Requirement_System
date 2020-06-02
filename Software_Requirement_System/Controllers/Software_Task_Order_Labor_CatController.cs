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
    public class Software_Task_Order_Labor_CatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Software_Task_Order_Labor_Cat
        public ActionResult Index()
        {
            var software_Task_Order_Labor_Cats = db.Software_Task_Order_Labor_Cats.Include(s => s.Software_Task_Order);
            return View(software_Task_Order_Labor_Cats.ToList());
        }

        // GET: Software_Task_Order_Labor_Cat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Task_Order_Labor_Cat software_Task_Order_Labor_Cat = db.Software_Task_Order_Labor_Cats.Find(id);
            if (software_Task_Order_Labor_Cat == null)
            {
                return HttpNotFound();
            }
            return View(software_Task_Order_Labor_Cat);
        }

        // GET: Software_Task_Order_Labor_Cat/Create
        public ActionResult Create()
        {
            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name");
            return View();
        }

        // POST: Software_Task_Order_Labor_Cat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Software_Task_OrderID,LaborCategory")] Software_Task_Order_Labor_Cat software_Task_Order_Labor_Cat)
        {
            if (ModelState.IsValid)
            {
                db.Software_Task_Order_Labor_Cats.Add(software_Task_Order_Labor_Cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name", software_Task_Order_Labor_Cat.Software_Task_OrderID);
            return View(software_Task_Order_Labor_Cat);
        }

        // GET: Software_Task_Order_Labor_Cat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Task_Order_Labor_Cat software_Task_Order_Labor_Cat = db.Software_Task_Order_Labor_Cats.Find(id);
            if (software_Task_Order_Labor_Cat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name", software_Task_Order_Labor_Cat.Software_Task_OrderID);
            return View(software_Task_Order_Labor_Cat);
        }

        // POST: Software_Task_Order_Labor_Cat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Software_Task_OrderID,LaborCategory")] Software_Task_Order_Labor_Cat software_Task_Order_Labor_Cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software_Task_Order_Labor_Cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name", software_Task_Order_Labor_Cat.Software_Task_OrderID);
            return View(software_Task_Order_Labor_Cat);
        }

        // GET: Software_Task_Order_Labor_Cat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Task_Order_Labor_Cat software_Task_Order_Labor_Cat = db.Software_Task_Order_Labor_Cats.Find(id);
            if (software_Task_Order_Labor_Cat == null)
            {
                return HttpNotFound();
            }
            return View(software_Task_Order_Labor_Cat);
        }

        // POST: Software_Task_Order_Labor_Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Software_Task_Order_Labor_Cat software_Task_Order_Labor_Cat = db.Software_Task_Order_Labor_Cats.Find(id);
            db.Software_Task_Order_Labor_Cats.Remove(software_Task_Order_Labor_Cat);
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
