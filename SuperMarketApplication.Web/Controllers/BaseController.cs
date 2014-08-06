using SuperMarketApplication.DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarketApplication.Data.Models;
using System.Text;
using System.Security.Cryptography;

namespace SuperMarketApplication.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var userId = this.Request.Cookies["userId"];
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            if ((userId == null || string.IsNullOrWhiteSpace(userId.Value)) && controllerName != "AccountController")
            {
                // Redirect to login here
                this.Response.RedirectToRoute("LogIn");
                return;
            }

            User user;
            using (var userRepository = new UsersRepository())
            {
                user = userRepository.GetUser(Guid.Parse(userId.Value));
            }

            this.ViewBag.UserId = user.Id.ToString();
            this.ViewBag.UserName = user.FirstName;

            using (var md5Hash = MD5.Create())
            {
                var emailHash = GetMd5Hash(md5Hash, user.Email);
                this.ViewBag.EmailHash = emailHash;
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
