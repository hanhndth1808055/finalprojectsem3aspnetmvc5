using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OfficialFinalProjectSem3.Data;
using OfficialFinalProjectSem3.Models;

namespace OfficialFinalProjectSem3.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        private MyDBContext db;
        // private RoleManager<ApplicationRole> roleManager;
        // private UserManager<ApplicationUser> userManager;

        public RolesController()
        {
        }

        // GET: Roles
        public ActionResult Index()
        {
            return RedirectToRoute("/Home");
        }

        public ActionResult Create(string roleName)
        {
            // db = HttpContext.GetOwinContext().Get<MyDBContext>();
            // var abc = db.Products.Find(1);
            // Debug.WriteLine(abc.Name);
            var result = HttpContext.GetOwinContext().Get<ApplicationRoleManager>().CreateAsync(new ApplicationRole(roleName));
            TempData["message"] = "Add role success!";
            return Redirect("/Home");
        }

        public ActionResult AddUserToRole(string username, string roleName)
        {
            Debug.WriteLine(username + " - " + roleName);
            db = HttpContext.GetOwinContext().Get<MyDBContext>();
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            Debug.WriteLine((HttpContext.GetOwinContext().Get<ApplicationRoleManager>().RoleExists(roleName)));
            if (user == null)
            {
                return HttpNotFound();
            }

            if (HttpContext.GetOwinContext().Get<ApplicationRoleManager>().RoleExists(roleName))
            {
                HttpContext.GetOwinContext().Get<ApplicationUserManager>().AddToRole(user.Id, roleName);
                TempData["message"] = "Add role success!";
                return Redirect("/Home");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}