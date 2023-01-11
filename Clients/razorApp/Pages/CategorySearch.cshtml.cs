using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace razorApp.Pages
{
    public class CategorySearch : PageModel
    {
        private readonly ILogger<CategorySearch> _logger;

        public CategorySearch(ILogger<CategorySearch> logger)
        {
            _logger = logger;
        }

    //     public async Task OnGet(int id)
    //     {
    //         using var http = new HttpClient();

    //         var baseUrl = _config.GetValue<string>("baseUrl");
    //         var url = $"{baseUrl}/category/{id}";
    //         CourseModel = await http.GetFromJsonAsync<CourseViewModel>(url) ?? new CourseViewModel();
    //     }
    // 
    }
}