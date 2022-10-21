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
    public class UpdateCourse : PageModel
    {
        private readonly ILogger<UpdateCourse> _logger;
        private readonly string _baseUrl;
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        [BindProperty]
        public UpdateCourseViewModel CourseModel { get; set; }

        public UpdateCourse(ILogger<UpdateCourse> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _baseUrl = _config.GetValue<string>("baseUrl");
            _http = new HttpClient();
        }

        public async Task<IActionResult>  OnGetAsync(int id)
        {
            var url = $"{_baseUrl}/courses/{id}";
            var course = await _http.GetFromJsonAsync<CourseViewModel>(url);
            var courseToUpdate = new UpdateCourseViewModel
            {
                CourseId = course.CourseId,
                CourseNumber = course.CourseNumber,
                Title = course.Title,
                Lenght = course.Lenght,
                Category = course.Category,
                Description = course.Description,
                Details = course.Details,
                ImageUrl = course.ImageUrl

            };

            CourseModel = courseToUpdate;
            _http.Dispose();

            return Page();
        }

        public async Task OnPostAsync()
        {
            var url = $"{_baseUrl}/courses/{CourseModel.CourseId}";

            var response = await _http.PutAsJsonAsync(url, CourseModel);

            if (!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
        }
    }
}
