using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razorApp.Pages.Administration
{
    public class TeacherGallery : PageModel
    {
        private readonly ILogger<TeacherGallery> _logger;

        public TeacherGallery(ILogger<TeacherGallery> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
