using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcTodo.Models;
using MvcTodo.Services;
using Xunit;

namespace MvcTodo.Test.Services {
  public class LoginServiceTest {
    private AuthService service;

    public LoginServiceTest() {
      var dbOptions = new DbContextOptionsBuilder<MvcTodoContext>().UseInMemoryDatabase("test").Options;
      var dbContext = new MvcTodoContext(dbOptions);
      var repo = new MvcTodo.Repo.UserRepo(dbContext);
      dbContext.Users.RemoveRange(dbContext.Users);
      dbContext.Users.Add(new User() {
        Username = "test",
          Password = new PasswordHasher<string>().HashPassword("test", "test")
      });
      dbContext.SaveChanges();
      this.service = new MvcTodo.Services.AuthService(repo);
    }

    [Fact]
    public void LoginServiceShouldReturnTrueIfLoginSuccessful() {
      Assert.True(service.Login("test", "test"));
    }

    [Fact]
    public void LoginServiceShouldReturnFalseIfInvalidUSername() {
      Assert.False(service.Login("testwrong", "test"));
    }

    [Fact]
    public void LoginServiceShouldReturnFalseIfInvalidPassword() {
      Assert.False(service.Login("test", "wrongPassword"));
    }
  }
}
