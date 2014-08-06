using SuperMarketApplication.DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarketApplication.Data.Models;

namespace SuperMarketApplication.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(string email, string password)
        {
            // Do login
            User user;
            using (var userRepository = new UsersRepository())
            {
                if (!userRepository.ValidateUser(email, password))
                {
                    return this.RedirectToAction("Index");
                }

                user = userRepository.GetUser(email);
            }

            this.Response.Cookies.Add(new HttpCookie("userId", user.Id.ToString()));

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            var cookie = this.Request.Cookies["userId"];
            cookie.Expires = DateTime.UtcNow.AddDays(-1);
            this.Response.Cookies.Add(cookie);

            return this.RedirectToAction("Index");
        }

        public ActionResult Register(string firstName, string email, string password, string confirmPassword)
        {
            using (var userRepository = new UsersRepository())
            {
                userRepository.CreateUser(firstName, email, password);
            }

            return this.LogIn(email, password);
        }

    }
}
