using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore2.Models
{
    public class TodoModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Completed { get; set; }

        public static ConcurrentBag<TodoModel> Todos = new ConcurrentBag<TodoModel>();
    }
}
