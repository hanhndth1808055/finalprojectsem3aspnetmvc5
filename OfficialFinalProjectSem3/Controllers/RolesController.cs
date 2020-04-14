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
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public RolesController()
        {
        }

        public RolesController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        // GET: Roles
        public ActionResult Index()
        {
            return RedirectToRoute("/Home");
        }

        public ActionResult Create(string roleName)
        {
            db = HttpContext.GetOwinContext().Get<MyDBContext>();
            var abc = db.Products.Find(1);
            Debug.WriteLine(abc.Name);
           RoleManager.CreateAsync(new ApplicationRole(roleName));
            TempData["message"] = "Add role success!";
            return Redirect("/Home");
        }

        public ActionResult AddUserToRole(string username, string roleName)
        {
            Debug.WriteLine(username + " - " + roleName);
            db = HttpContext.GetOwinContext().Get<MyDBContext>();
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            Debug.WriteLine((RoleManager.RoleExists(roleName)));
            if (user == null)
            {
                return HttpNotFound();
            }

            if (RoleManager.RoleExists(roleName))
            {
                UserManager.AddToRole(user.Id, roleName);
                TempData["message"] = "Add role success!";
                return Redirect("/Home");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}