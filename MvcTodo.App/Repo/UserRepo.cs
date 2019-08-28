using System.Linq;
using MvcTodo.Models;

namespace MvcTodo.Repo {
  public interface IUserRepo {
    User getByUsername(string username);
  }

  public class UserRepo : IUserRepo {
    private MvcTodoContext context;

    public UserRepo(MvcTodoContext context) {
      this.context = context;
    }

    public User getByUsername(string username) {
      return context.Users.FirstOrDefault(user => user.Username == username);
    }
  }
}
