using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaConnessioneLicenze.Models;

namespace ProvaConnessioneLicenze.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verify(Admin usr)
        {
            if (usr.Username == "admin" & usr.Password == "ciao")
            {
                ViewBag.message = "Login Success";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return RedirectToAction("Login");
            }
        }
    }
}