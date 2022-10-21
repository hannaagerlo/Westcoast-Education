using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razorApp.Pages.Administration
{
    public class UpdateStudent : PageModel
    {
        private readonly ILogger<UpdateStudent> _logger;

        public UpdateStudent(ILogger<UpdateStudent> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
