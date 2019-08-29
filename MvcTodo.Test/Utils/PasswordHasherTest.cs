using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcTodo.Utils;
using Xunit;

namespace MvcTodo.Test {
  public class PasswordHasherTest {

    [Fact]
    public void TestVerifyPasswordReturnTrueWhenCorrect() {
      var hashed = PasswordUtils.Hashpassword("aaa");
      Assert.NotEqual(hashed, "aaa");
      Assert.True(PasswordUtils.Verify(hashed, "aaa"));
    }

    [Fact]
    public void TestVerifyPasswordReturnFalseWhenIncorrect() {
      var hashed = PasswordUtils.Hashpassword("aaa");
      Assert.False(PasswordUtils.Verify(hashed, "aaa22"));
    }
  }
}
