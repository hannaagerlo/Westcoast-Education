using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razorApp.Pages.Administration
{
    public class CreateTeacher : PageModel
    {
        private readonly ILogger<CreateTeacher> _logger;

        public CreateTeacher(ILogger<CreateTeacher> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
