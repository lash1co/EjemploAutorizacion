using EjercicioLogin.Views.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioLogin.Controllers
{
    [Authorize] //Autorizacion Global
    public class HomeController : Controller
    {
        //[Authorize] //Autorizacion Local
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizeUser(oRol:"Administrador")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}