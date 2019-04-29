using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRealProject.Models;
using MyRealProject.Realization;
using MyRealProject.Repository;
using Ninject.Infrastructure.Language;

namespace MyRealProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var userr = _userRepository
                    .GetMany(x => x.Email == user.Email && x.Password == user.Password && x.IsActive == true)
                    .SingleOrDefault();
                if (userr != null)
                {
                    if (userr.Role.RoleName == "Admin")
                    {
                        Session["UserEmail"] = userr.Id;
                        return RedirectToAction("Index", "Home");
                    }

                    ViewBag.Message = "Unauthorized user";
                    return View(userr);
                }
            }
            ViewBag.Mes = "User not found";
            return View();
        }
    }
}