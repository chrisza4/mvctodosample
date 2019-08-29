using Microsoft.AspNetCore.Identity;

namespace MvcTodo.Utils {
  public class PasswordUtils {
    public static string Hashpassword(string password) {
      return new PasswordHasher<string>().HashPassword("MvcTodo", password);
    }

    public static bool Verify(string hashedPassword, string password) {
      var verifyResult = new PasswordHasher<string>().VerifyHashedPassword("MvcTodo", hashedPassword, password);
      return verifyResult.HasFlag(PasswordVerificationResult.Success);
    }
  }
}
