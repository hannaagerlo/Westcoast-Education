using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorApp.ViewModels;

namespace razorApp.Pages.Administration
{
    public class CreateCategory : PageModel
    {
        private readonly ILogger<CreateCategory> _logger;

        [BindProperty]
        public CreateCategoryViewModel CategoryModel { get; set; }
        private readonly IConfiguration _config;

        public CreateCategory(ILogger<CreateCategory> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            using var http = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/category";
            var response = await http.PostAsJsonAsync(url, CategoryModel);

            if(!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
            Response.Redirect("/Administration/CourseGallery");
            return;
        
        }
    }
}