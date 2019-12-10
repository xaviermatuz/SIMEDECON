using System;
using System.Collections.Generic;
using System.Linq;
using SIMEDECON.Models;
using SIMEDECON.Models.ViewModel;
using System.Web;
using System.Web.Mvc;

namespace SIMEDECON.Controllers
{
    public class AtletaController : Controller
    {
        DAL objdal = new DAL();
        MeSysEntities ME = new MeSysEntities();//LLamada a Entityframework, para seleccion de tabla
        // GET: Atleta
        public ActionResult Index()
        {

            IEnumerable<Datos_Atleta> Atleta = ME.Datos_Atleta.Where(s => s.Activo.ToString() == "true");
            ViewBag.Atleta = Atleta;
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Actualizar()
        {
            return View();
        }
        public ActionResult Mostrar()
        {           
            return View();
        }

        //POST

    }
}
