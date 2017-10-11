using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPCore2.Models;

namespace ASPCore2.Pages.Todo
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public TodoModel Todo { get; set; }

        public void OnGet()
        {
            Todo = new TodoModel { Title = "What needs to be done?" };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TodoModel.Todos.Add(Todo);

            return RedirectToPage("./Index");
        }
    }
}