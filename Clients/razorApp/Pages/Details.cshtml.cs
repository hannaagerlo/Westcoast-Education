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
    public class Details : PageModel
    {
        private readonly ILogger<Details> _logger;
        private readonly IConfiguration _config;
         public CourseViewModel? CourseModel { get; set; }

        public Details(ILogger<Details> logger, IConfiguration config)
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

        public async Task OnPostRegisterToCourse(int id)
        {
            using var httpClient = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            await httpClient.PostAsJsonAsync<int>($"{baseUrl}/courses/signup/{id}", id);

            await OnGet(id);
        }
        // public async Task OnPostAsync(int courseId)
        // {
        //     using var http = new HttpClient();
        //     var baseUrl = _config.GetValue<string>("baseUrl");
        //     string url = $"{baseUrl}/signup/{courseId}";
        //     // string studentUrl = $"{baseUrl}/Students/getUser";

        //     var model = new StudentWithCourseViewModel()
        //     {
        //         CourseId = courseId
        //     };
        
        //     var response = await http.PostAsJsonAsync(url, model);
        //     // if (response.IsSuccessStatusCode)
        //     // {
        //     //     ViewData["Message"] = $"Studenten har registrerat sig på den här kursen";
                
        //     // }
        //     // else
        //     // {
        //     //     ViewData["Message"] = $"Fel inträffade vid registrering";
        //     // }

            
        //     if(!response.IsSuccessStatusCode)
        //     {
        //         string reason = await response.Content.ReadAsStringAsync();
        //         Console.WriteLine(reason);
        //     }
        //     Response.Redirect("/RegistraionConfirmation");
        //     return;
        // }
    }
}
