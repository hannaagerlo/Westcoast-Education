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
    [BindProperties]
    public class DeleteCourse : PageModel
    {
        private readonly ILogger<DeleteCourse> _logger;

        private readonly IConfiguration _config;
        
         public CourseViewModel? CourseModel { get; set; }

        public DeleteCourse(ILogger<DeleteCourse> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

         public async Task OnGet(int id)
        {
            using var http = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/courses/{id}";
            CourseModel = await http.GetFromJsonAsync<CourseViewModel>(url) ?? new CourseViewModel();
        }

        public async Task OnPostAsync()
        {
            using var http = new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            string url = $"{baseUrl}/courses/{CourseModel!.CourseId}";

            var response = await http.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Response.Redirect("/Administration/CourseGallery");
                return;
            }
            throw new Exception("Failed to delete course");
        }

    }
}