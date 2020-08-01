using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using QuanLyCapNuoc.Areas.Admin.Data;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class UserTypeController : Controller
    {
        // GET: Admin/UserType
        public ActionResult Index()
        {
            UserTypeDao db = new UserTypeDao();
            List<LoaiKhachHang> list = db.List();
            LoaiKhachHang type = new LoaiKhachHang();
            ViewData["list"] = list;
            ViewData["type"] = type;
            return View();
        }
        public ActionResult Store(LoaiKhachHang model)
        {
            try
            {

            UserTypeDao db = new UserTypeDao();
            db.Insert(model);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Thêm thành công.");
                return RedirectToAction("Index", "UserType");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể thêm.");
            return RedirectToAction("Index", "UserType");
        }
        public ActionResult Edit(String code)
        {
            var type = new UserTypeDao().GetByID(code);
            return View(type);
        }
        public ActionResult Update(LoaiKhachHang model)
        {
            try { 
                var type = new UserTypeDao().Update(model);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Cập nhật thành công.");
                return RedirectToAction("Index", "UserType");
            }
            catch(Exception e) 
            { 
                Console.WriteLine(e.Message); 
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể cập nhật.");
            return RedirectToAction("Index", "UserType");


        }
        public ActionResult Destroy(string code)
        {
            try
            {

            var type = new UserTypeDao().Destroy(code);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Xóa thành công.");
                return RedirectToAction("Index", "UserType");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể xóa.");
            return RedirectToAction("Index", "UserType");
        }
    }
}