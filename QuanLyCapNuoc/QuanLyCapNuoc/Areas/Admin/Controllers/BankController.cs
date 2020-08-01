using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class BankController : Controller
    {
        // GET: Admin/Bank
        public ActionResult Index()
        {
            BankDao db = new BankDao();
            List<NganHang> list = db.List();
            NganHang type = new NganHang();
            ViewData["list"] = list;
            return View();
        }
        public ActionResult Store(NganHang model)
        {
            try
            {

                BankDao db = new BankDao();
                db.Insert(model);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Thêm thành công.");
                return RedirectToAction("Index", "Bank");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể thêm.");
            return RedirectToAction("Index", "Bank");
        }
        public ActionResult Edit(int code)
        {
            var type = new BankDao().GetByID(code);
            return View(type);
        }
        public ActionResult Update(NganHang model)
        {
            try
            {
                var type = new BankDao().Update(model);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Cập nhật thành công.");
                return RedirectToAction("Index", "Bank");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể cập nhật.");
            return RedirectToAction("Index", "Bank");


        }
        public ActionResult Destroy(int code)
        {
            try
            {

                var type = new BankDao().Destroy(code);
                if (TempData["ModelSuccess"] == null)
                    TempData.Add("ModelSuccess", "Xóa thành công.");
                return RedirectToAction("Index", "Bank");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (TempData["ModelErrors"] == null)
                TempData.Add("ModelErrors", "Có lỗi xảy ra! Không thể xóa.");
            return RedirectToAction("Index", "Bank");
        }
    }
}