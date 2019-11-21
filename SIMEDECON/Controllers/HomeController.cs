using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMEDECON.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {        
        [Authorize(Roles ="Administrador")]
        public ActionResult ViewAdministrador()
        {
            return View();
        }
        [Authorize(Roles = "Medico,Administrador")]
        public ActionResult ViewMedico()
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