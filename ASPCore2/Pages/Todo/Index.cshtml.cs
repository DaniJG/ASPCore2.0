using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPCore2.Models;

namespace ASPCore2.Pages.Todo
{
    public class IndexModel : PageModel
    {
        public IEnumerable<TodoModel> Todos { get; set; }
        public void OnGet()
        {
            Todos = TodoModel.Todos.ToList();
        }
    }
}