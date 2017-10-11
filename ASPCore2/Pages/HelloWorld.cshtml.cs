using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore2.Pages
{
    public class HelloWorldModel : PageModel
    {
        public HelloWorldModel(IHostingEnvironment env)
        {
            PhysicalPath = env.ContentRootPath;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public string PhysicalPath { get; set; }
        public DateTime ServerTime { get; set; }

        public void OnGet()
        {
            ServerTime = DateTime.Now;
        }
    }
}
