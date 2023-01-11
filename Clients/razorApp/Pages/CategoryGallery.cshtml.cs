using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorApp.ViewModels;

namespace razorApp.Pages
{
    public class CategoryGallery : PageModel
    {
        private readonly ILogger<CategoryGallery> _logger;
        private readonly IConfiguration _config;

        [BindProperty]
        public List<CategoryWithCoursesViewModel> Categories { get; set; }

        public CategoryGallery(ILogger<CategoryGallery> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

         public async Task OnGetAsync()
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/category/listWithCourses";

            using var http = new HttpClient();
            Categories = await http.GetFromJsonAsync<List<CategoryWithCoursesViewModel>>(url);
        }
    }
}