using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Phase2Nandoso.DAL;
using Phase2Nandoso.Models;

namespace Phase2Nandoso.Controllers
{
    public class ReplyController : Controller
    {
        private NandosoContext db = new NandosoContext();

        // GET: Reply
        public ActionResult Index()
        {
            var replys = db.Replys.Include(r => r.Employee).Include(r => r.Feedback);
            return View(replys.ToList());
        }

        // GET: Reply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replys.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // GET: Reply/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName");
            ViewBag.FeedbackID = new SelectList(db.Feedbacks, "ID", "CustomerName");
            return View();
        }

        // POST: Reply/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FeedbackID,EmployeeID,Content")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Replys.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", reply.EmployeeID);
            ViewBag.FeedbackID = new SelectList(db.Feedbacks, "ID", "CustomerName", reply.FeedbackID);
            return View(reply);
        }

        // GET: Reply/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replys.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", reply.EmployeeID);
            ViewBag.FeedbackID = new SelectList(db.Feedbacks, "ID", "CustomerName", reply.FeedbackID);
            return View(reply);
        }

        // POST: Reply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FeedbackID,EmployeeID,Content")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", reply.EmployeeID);
            ViewBag.FeedbackID = new SelectList(db.Feedbacks, "ID", "CustomerName", reply.FeedbackID);
            return View(reply);
        }

        // GET: Reply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replys.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Reply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply reply = db.Replys.Find(id);
            db.Replys.Remove(reply);
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
