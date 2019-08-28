using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcTodo.Controllers;
using MvcTodo.Services;
using Xunit;

namespace MvcTodo.Test {
  public class LoginControllerTest {

    [Fact]
    public void TestPostLoginControllerShouldStillLoginWhenLoginFailed() {
      var mockLoginService = new Mock<IAuthService>();
      mockLoginService.Setup(service => service.Login("test", "test")).Returns(false);

      var controller = new LoginController(mockLoginService.Object);
      var res = controller.PostLogin("test", "test");
      Assert.IsType<ViewResult>(res);
      var viewResult = res as ViewResult;
      Assert.Equal("Login", viewResult.ViewName);
    }

    [Fact]
    public void TestPostLoginControllerShouldRedirectToSecretPageOnceSuccess() {
      var mockLoginService = new Mock<IAuthService>();
      mockLoginService.Setup(service => service.Login("test2", "test2")).Returns(true);
      var controller = new LoginController(mockLoginService.Object);
      var res = controller.PostLogin("test2", "test2");
      Assert.IsType<RedirectToActionResult>(res);

      var redirectResult = res as RedirectToActionResult;
      Assert.Equal("SecretPage", redirectResult.ActionName);
    }

    [Fact]
    public void TestPostLoginNoUsernameShouldReturnLoginWithErrorMessage() {
      var mockLoginService = new Mock<IAuthService>();
      var controller = new LoginController(mockLoginService.Object);
      var res = controller.PostLogin("", "test");
      Assert.IsType<ViewResult>(res);
      var viewResult = res as ViewResult;
      Assert.Equal("Login", viewResult.ViewName);
      Assert.Equal("Please enter username", viewResult.ViewData["errorMessage"]);
    }

    [Fact]
    public void TestPostLoginNoPasswordShouldReturnLoginWithErrorMessage() {
      var mockLoginService = new Mock<IAuthService>();
      var controller = new LoginController(mockLoginService.Object);
      var res = controller.PostLogin("ttt", "");
      Assert.IsType<ViewResult>(res);
      var viewResult = res as ViewResult;
      Assert.Equal("Login", viewResult.ViewName);
      Assert.Equal("Please enter password", viewResult.ViewData["errorMessage"]);
    }

    [Fact]
    public void TestPostLoginInvalidAuthenticationShouldReturnErrorMessage() {
      var mockLoginService = new Mock<IAuthService>();
      mockLoginService.Setup(service => service.Login("test", "test")).Returns(false);
      var controller = new LoginController(mockLoginService.Object);
      var res = controller.PostLogin("test", "test");
      Assert.IsType<ViewResult>(res);
      var viewResult = res as ViewResult;
      Assert.Equal("Login", viewResult.ViewName);
      Assert.Equal("Invalid username or password", viewResult.ViewData["errorMessage"]);
    }
  }
}
