using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcTodo.Models;

namespace MvcTodo.Controllers {
  public class LoginController : Controller {
    public IActionResult Login() {
      return View("Login");
    }

    public IActionResult Signup() {
      return View("Signup");
    }

    public IActionResult ForgetPassword() {
      return View("ForgetPassword");
    }
  }
}
