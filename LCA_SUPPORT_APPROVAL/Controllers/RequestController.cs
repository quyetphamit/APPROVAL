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
    public class RequestController : BaseController
    {
        private RequestEntity db = new RequestEntity();
        private tbl_User sess = new tbl_User();
        // GET: Request
        public ActionResult Index()
        {
            sess = Session["user"] as tbl_User;
            var tbl_Request = db.tbl_Request.Include(t => t.tbl_Customer).Include(t => t.tbl_User);
            ViewBag.totalRecord = db.tbl_Request.Where(r => r.userId_Approval == sess.user_Id).Count();
            return View(tbl_Request.ToList());
        }

        // GET: Request/Details/5
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

        // GET: Request/Create
        public ActionResult Create()
        {
            ViewBag.customer_Id = new SelectList(db.tbl_Customer, "customer_Id", "customer_Name");
            ViewBag.userId_Create = new SelectList(db.tbl_User, "user_Id", "username");
            ViewBag.group_Id = new SelectList(db.tbl_Group.Where(r => r.group_Name.Contains("LCA") && !r.group_Name.Contains("MNG")), "group_Id", "group_Name");
            return View();
        }

        // POST: Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId_Approval,userId_Update,customer_Id,quantity,dealLine,content,increaseProductivity,newModel,increaseProduction,improve,C_5s,checkJig,reducePeple,errorContent,currentError,afterError,other,pay,model,pcb,phone,contentDetail,cost,date_Update,date_Received,date_Finish,file_upload")] tbl_Request tbl_Request)
        {
            sess = Session["user"] as tbl_User;
            if (ModelState.IsValid)
            {
                tbl_Request.userId_Create = sess.user_Id;
                tbl_Request.date_Create = DateTime.Now;
                db.tbl_Request.Add(tbl_Request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_Id = new SelectList(db.tbl_Customer, "customer_Id", "customer_Name", tbl_Request.customer_Id);
            ViewBag.userId_Create = new SelectList(db.tbl_User, "user_Id", "username", tbl_Request.userId_Create);
            return View(tbl_Request);
        }

        // GET: Request/Edit/5
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

        // POST: Request/Edit/5
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

        // GET: Request/Delete/5
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

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Request tbl_Request = db.tbl_Request.Find(id);
            db.tbl_Request.Remove(tbl_Request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult FindUser(int deptId)
        {
            tbl_User user = db.tbl_User.Find(deptId);
            return Json(new {
                id = user.user_Id,
                name = user.fullname,
                phone = user.phone
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Test()
        {
            return View();
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
