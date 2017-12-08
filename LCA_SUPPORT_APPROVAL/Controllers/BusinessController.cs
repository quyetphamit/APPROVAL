using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LCA_SUPPORT_APPROVAL.Models;

namespace LCA_SUPPORT_APPROVAL.Controllers
{
    public class BusinessController : BaseController
    {
        private RequestEntity db = new RequestEntity();

        // GET: Business
        public ActionResult Index()
        {
            var tbl_Request = db.tbl_Request.Include(t => t.tbl_Customer).Include(t => t.tbl_User);
            return View(tbl_Request.ToList());
        }
        public ActionResult getRequestByUserApproval(int userId_Approval)
        {
            var result = db.tbl_Request.Where(r => r.userId_Approval == userId_Approval).ToList();
            return View(result);
        }
        // GET: Business/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Request tbl_Request = db.tbl_Request.Find(id);
            if (tbl_Request == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Request);
        }

        // GET: Business/Create
        public ActionResult Create()
        {
            ViewBag.customer_Id = new SelectList(db.tbl_Customer, "customer_Id", "customer_Name");
            ViewBag.userId_Create = new SelectList(db.tbl_User, "user_Id", "username");
            return View();
        }

        // POST: Business/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,userId_Create,userId_Approval,userId_Update,customer_Id,quantity,dealLine,content,increaseProductivity,newModel,increaseProduction,improve,C_5s,checkJig,reducePeple,errorContent,currentError,afterError,other,pay,model,pcb,phone,contentDetail,cost,date_Create,date_Update,date_Received,date_Finish,file_upload")] tbl_Request tbl_Request)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Request.Add(tbl_Request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_Id = new SelectList(db.tbl_Customer, "customer_Id", "customer_Name", tbl_Request.customer_Id);
            ViewBag.userId_Create = new SelectList(db.tbl_User, "user_Id", "username", tbl_Request.userId_Create);
            return View(tbl_Request);
        }

        // GET: Business/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Request tbl_Request = db.tbl_Request.Find(id);
            if (tbl_Request == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_Id = new SelectList(db.tbl_Customer, "customer_Id", "customer_Name", tbl_Request.customer_Id);
            ViewBag.userId_Create = new SelectList(db.tbl_User, "user_Id", "username", tbl_Request.userId_Create);
            return View(tbl_Request);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userId_Create,userId_Approval,userId_Update,customer_Id,quantity,dealLine,content,increaseProductivity,newModel,increaseProduction,improve,C_5s,checkJig,reducePeple,errorContent,currentError,afterError,other,pay,model,pcb,phone,contentDetail,cost,date_Create,date_Update,date_Received,date_Finish,file_upload")] tbl_Request tbl_Request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_Id = new SelectList(db.tbl_Customer, "customer_Id", "customer_Name", tbl_Request.customer_Id);
            ViewBag.userId_Create = new SelectList(db.tbl_User, "user_Id", "username", tbl_Request.userId_Create);
            return View(tbl_Request);
        }

        // GET: Business/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Request tbl_Request = db.tbl_Request.Find(id);
            if (tbl_Request == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Request);
        }

        // POST: Business/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Request tbl_Request = db.tbl_Request.Find(id);
            db.tbl_Request.Remove(tbl_Request);
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
