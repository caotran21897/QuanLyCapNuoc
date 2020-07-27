using QuanLyCapNuoc.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using QuanLyCapNuoc.common;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.nv_tendangnhap, model.nv_matkhau);
                if (result)
                {
                    var user = dao.GetByID(model.nv_tendangnhap);
                    var nvSession = new UserLogin();
                    nvSession.nv_name = user.nv_tendangnhap;
                    nvSession.nv_ID = user.nv_id;
                    Session.Add(CommonConstants.NV_SESSION, nvSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            return View("Index");
        }
    }
}