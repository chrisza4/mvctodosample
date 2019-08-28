using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MvcTodo.Models {
  public class MvcTodoContext : DbContext {
    public MvcTodoContext(DbContextOptions<MvcTodoContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
  }
}
