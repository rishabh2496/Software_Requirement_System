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
    public class Software_Project_TaskController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Software_Project_Task
        public ActionResult Index()
        {
            var software_Project_Tasks = db.Software_Project_Tasks.Include(s => s.Software_Project);
            return View(software_Project_Tasks.ToList());
        }

        // GET: Software_Project_Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Project_Task software_Project_Task = db.Software_Project_Tasks.Find(id);
            if (software_Project_Task == null)
            {
                return HttpNotFound();
            }
            return View(software_Project_Task);
        }

        // GET: Software_Project_Task/Create
        public ActionResult Create()
        {
            ViewBag.Software_ProjectID = new SelectList(db.Software_Projects, "ID", "Name");
            return View();
        }

        // POST: Software_Project_Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Software_ProjectID")] Software_Project_Task software_Project_Task)
        {
            if (ModelState.IsValid)
            {
                db.Software_Project_Tasks.Add(software_Project_Task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Software_ProjectID = new SelectList(db.Software_Projects, "ID", "Name", software_Project_Task.Software_ProjectID);
            return View(software_Project_Task);
        }

        // GET: Software_Project_Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Project_Task software_Project_Task = db.Software_Project_Tasks.Find(id);
            if (software_Project_Task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Software_ProjectID = new SelectList(db.Software_Projects, "ID", "Name", software_Project_Task.Software_ProjectID);
            return View(software_Project_Task);
        }

        // POST: Software_Project_Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Software_ProjectID")] Software_Project_Task software_Project_Task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(software_Project_Task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Software_ProjectID = new SelectList(db.Software_Projects, "ID", "Name", software_Project_Task.Software_ProjectID);
            return View(software_Project_Task);
        }

        // GET: Software_Project_Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Software_Project_Task software_Project_Task = db.Software_Project_Tasks.Find(id);
            if (software_Project_Task == null)
            {
                return HttpNotFound();
            }
            return View(software_Project_Task);
        }

        // POST: Software_Project_Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Software_Project_Task software_Project_Task = db.Software_Project_Tasks.Find(id);
            db.Software_Project_Tasks.Remove(software_Project_Task);
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
