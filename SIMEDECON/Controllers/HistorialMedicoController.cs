using SIMEDECON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMEDECON.Controllers
{
    public class HistorialMedicoController : Controller
    {
        public MeSysEntities db = new MeSysEntities();
        // GET: HistorialMedico
        public Datos_Atleta GetDA(int ID)
        {
            Datos_Atleta model = new Datos_Atleta();
            Datos_Atleta da = db.Datos_Atleta.Find(ID);
            model.ID = da.ID;
            model.Nombre_Completo = da.Nombre_Completo;
            ViewBag.Nombre = model.Nombre_Completo;
            return model;
        }
        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Actualizar()
        {
            return View();
        }

    }
}