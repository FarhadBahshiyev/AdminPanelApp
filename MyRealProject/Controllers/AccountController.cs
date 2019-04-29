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
                var currentUser = _userRepository
                    .GetMany(x => x.Email == user.Email && x.Password == user.Password && x.IsActive == true)
                    .SingleOrDefault();
                if (currentUser != null)
                {
                    if (currentUser.Role.RoleName == "Admin")
                    {
                        Session["Admin"] = currentUser.Id;
                        return RedirectToAction("Index", "Home");
                    }

                    ViewBag.Message = "Unauthorized user";
                    return View(currentUser);
                }
            }
            ViewBag.Mes = "User not found";
            return View();
        }
    }
}