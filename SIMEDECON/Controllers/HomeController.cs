using SIMEDECON.Models;
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
        public MeSysEntities db = new MeSysEntities();
        [Authorize(Roles ="Administrador")]
        public ActionResult ViewAdministrador()
        {
            IEnumerable<AspNetUser> User = db.AspNetUsers;
            ViewBag.Usuario = User;
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