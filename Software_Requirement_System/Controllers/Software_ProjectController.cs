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
    public class Software_ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Software_Project
        public ActionResult Index()
        {
            var software_Projects = db.Software_Projects.Include(s => s.Software_Task_Order);
            return View(software_Projects.ToList());
        }

        // GET: Software_Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Project software_Project = db.Software_Projects.Find(id);
            if (software_Project == null)
            {
                return HttpNotFound();
            }
            return View(software_Project);
        }

        // GET: Software_Project/Create
        public ActionResult Create()
        {
            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name");
            return View();
        }

        // POST: Software_Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Software_Task_OrderID")] Software_Project software_Project)
        {
            if (ModelState.IsValid)
            {
                db.Software_Projects.Add(software_Project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name", software_Project.Software_Task_OrderID);
            return View(software_Project);
        }

        // GET: Software_Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Project software_Project = db.Software_Projects.Find(id);
            if (software_Project == null)
            {
                return HttpNotFound();
            }
            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name", software_Project.Software_Task_OrderID);
            return View(software_Project);
        }

        // POST: Software_Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Software_Task_OrderID")] Software_Project software_Project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software_Project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Software_Task_OrderID = new SelectList(db.Software_Task_Orders, "ID", "Name", software_Project.Software_Task_OrderID);
            return View(software_Project);
        }

        // GET: Software_Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Project software_Project = db.Software_Projects.Find(id);
            if (software_Project == null)
            {
                return HttpNotFound();
            }
            return View(software_Project);
        }

        // POST: Software_Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Software_Project software_Project = db.Software_Projects.Find(id);
            db.Software_Projects.Remove(software_Project);
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
