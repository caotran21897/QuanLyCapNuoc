using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCapNuoc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD
=======

        public ActionResult error404()
        {
            return View();
        }
        public ActionResult error500()
        {
            return View();
        }
>>>>>>> 887c4086883b3cb32355f5c14dbb2901599be6f8
    }
}