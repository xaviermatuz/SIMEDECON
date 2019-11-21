using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMEDECON.Controllers
{
    [AllowAnonymous]
    public class LandingController : Controller
    {
        // GET: Landing
        public ActionResult Index()
        {
            return View();
        }
    }
}