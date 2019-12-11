using SIMEDECON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMEDECON.Controllers
{
    [Authorize]
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

        [Authorize(Roles = "Medico,Administrador")]
        public ActionResult Crear(int ID)
        {
            var nom = db.Datos_Atleta.Find(ID);
            ViewBag.id = ID;
            ViewBag.nombre = nom.Nombre_Completo;
            IEnumerable<Carrera_Deportiva_Evento> cde = db.Carrera_Deportiva_Evento.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.cdetabla = cde;
            IEnumerable<Carrera_Deportiva_Familiar> cdf = db.Carrera_Deportiva_Familiar.Where(s => s.ID_Atleta == ID).ToList();
            ViewBag.cdftabla = cdf;            
            return View();
        }

        public ActionResult Actualizar()
        {
            return View();
        }

    }
}