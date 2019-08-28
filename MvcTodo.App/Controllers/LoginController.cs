using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MvcTodo.Models;
using MvcTodo.Services;

namespace MvcTodo.Controllers {
  public class LoginController : Controller {
    private IAuthService loginService;

    public LoginController(IAuthService loginService) {
      this.loginService = loginService;
    }

    [HttpGet]
    public IActionResult Login() {
      return View("Login");
    }

    [HttpPost]
    public IActionResult PostLogin(string username, string password) {
      var loginView = View("Login");
      if (string.IsNullOrEmpty(username)) {
        loginView.ViewData["errorMessage"] = "Please enter username";
        return loginView;
      }
      if (string.IsNullOrEmpty(password)) {
        loginView.ViewData["errorMessage"] = "Please enter password";
        return loginView;
      }
      if (!this.loginService.Login(username, password)) {
        loginView.ViewData["errorMessage"] = "Invalid username or password";
        return loginView;
      } else {
        return RedirectToAction("SecretPage");
      }

    }

    public IActionResult Signup() {
      return View("Signup");
    }

    public IActionResult ForgetPassword() {
      return View("ForgetPassword");
    }

    public IActionResult SecretPage() {
      return View("Secret");
    }
  }
}
