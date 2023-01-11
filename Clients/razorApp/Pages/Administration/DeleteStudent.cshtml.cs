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
    public class DeleteStudent : PageModel
    {
        private readonly ILogger<DeleteStudent> _logger;
         private readonly IConfiguration _config;
        
         public StudentViewModel? StudentModel { get; set; }

        public DeleteStudent(ILogger<DeleteStudent> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

          public async Task OnGet(int id)
        {
            using var http = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students/{id}";
            StudentModel = await http.GetFromJsonAsync<StudentViewModel>(url) ?? new StudentViewModel();
        }

        public async Task OnPostAsync()
        {
            using var http = new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            string url = $"{baseUrl}/students/{StudentModel!.StudentId}";

            var response = await http.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Response.Redirect("/Administration/StudentGallery");
                return;
            }
            throw new Exception("Failed to delete student");
        }
    }
}