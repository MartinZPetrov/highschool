using highschool.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace highschool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DisciplineDAL.GetDisciplines();
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
