using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razorApp.Pages.Administration
{
    public class StudentGallery : PageModel
    {
        private readonly ILogger<StudentGallery> _logger;

        public StudentGallery(ILogger<StudentGallery> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
