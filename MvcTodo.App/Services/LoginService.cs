using Microsoft.AspNetCore.Identity;
using MvcTodo.Repo;
using MvcTodo.Utils;

namespace MvcTodo.Services {
  public interface IAuthService {
    bool Login(string username, string password);
  }

  public class AuthService : IAuthService {
    public IUserRepo userRepo;
    public AuthService(IUserRepo userRepo) {
      this.userRepo = userRepo;
    }

    public bool Login(string username, string password) {
      var user = userRepo.getByUsername(username);
      if (user == null) {
        return false;
      }
      var hasher = new PasswordHasher<string>();

      return PasswordUtils.Verify(user.Password, password);
    }

  }
}
