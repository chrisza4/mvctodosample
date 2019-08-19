using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcTodo.Models;

namespace MvcTodo.Controllers {
    public class TodoController : Controller {
        public IActionResult Index() {
            var todos = new List<TodoModel>() {
                new TodoModel() { Id = "1", Title = "Done deal!!", IsCompleted = true },
                new TodoModel() { Id = "2", Title = "Do this please", IsCompleted = false },
                new TodoModel() { Id = "3", Title = "Do this too please", IsCompleted = false },
            };
            // Upper close should be replaced with internal system logics
            return View(todos);
        }

        public IActionResult NewFeature() {
            return View("New feature");
        }
    }
}
