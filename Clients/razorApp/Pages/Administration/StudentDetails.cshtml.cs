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
    public class StudentDetails : PageModel
    {
        private readonly ILogger<StudentDetails> _logger;
        private readonly IConfiguration _config;

        //  [BindProperty]
        //  public List<StudentWithCourseViewModel> StudentCourseModel { get; set; }

          [BindProperty]
         public StudentWithCourseViewModel StudentCourseModel { get; set; }

        public StudentDetails(ILogger<StudentDetails> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task OnGet(int studentId)
        {
            using var http = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students/studentsWithCourses/{studentId}";
            // StudentCourseModel = await http.GetFromJsonAsync<List<StudentWithCourseViewModel>>(url);
            // StudentCourseModel = await http.GetFromJsonAsync<StudentWithCourseViewModel>(url);

             StudentCourseModel = await http.GetFromJsonAsync<StudentWithCourseViewModel>(url) ?? new StudentWithCourseViewModel();
        }
        
    }
}