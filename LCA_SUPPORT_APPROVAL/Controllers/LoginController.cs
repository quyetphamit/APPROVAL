using LCA_SUPPORT_APPROVAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LCA_SUPPORT_APPROVAL.Controllers
{
    public class LoginController : Controller
    {
        private RequestEntity db = new RequestEntity();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(tbl_User user)
        {
            var userDetail = db.tbl_User.Where(r => r.username == user.username && r.pass == user.pass).FirstOrDefault();
            if (userDetail == null)
            {
                ViewBag.loginInvalid = "Tên đăng nhập hoặc mật khẩu sai";
                return RedirectToAction("Index");
            }
            Session["user"] = userDetail;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}