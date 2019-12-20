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
            //IEnumerable<AspNetUser> User = db.AspNetUsers;
            //ViewBag.Usuario = User;
            //return View();
            using (var context = new ApplicationDbContext())
            {
                var sql = @"
            SELECT AspNetUsers.UserName,AspNetUsers.Id,AspNetUsers.Email, AspNetRoles.Name As Role
            FROM AspNetUsers 
            LEFT JOIN AspNetUserRoles ON  AspNetUserRoles.UserId = AspNetUsers.Id 
            LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId";
                //WHERE AspNetUsers.Id = @Id";
                //var idParam = new SqlParameter("Id", theUserId);

                var result = context.Database.SqlQuery<UserWithRolViewModel>(sql).ToList();
                return View(result);
            }
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