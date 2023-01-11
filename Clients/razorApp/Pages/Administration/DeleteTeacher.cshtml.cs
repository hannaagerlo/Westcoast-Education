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
    public class DeleteTeacher : PageModel
    {
        private readonly ILogger<DeleteTeacher> _logger;
         private readonly IConfiguration _config;
        
         public TeacherViewModel? TeacherModel { get; set; }

        public DeleteTeacher(ILogger<DeleteTeacher> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

          public async Task OnGet(int id)
        {
            using var http = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/teachers/{id}";
            TeacherModel = await http.GetFromJsonAsync<TeacherViewModel>(url) ?? new TeacherViewModel();
        }

        public async Task OnPostAsync()
        {
            using var http = new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            string url = $"{baseUrl}/teachers/{TeacherModel!.TeacherId}";

            var response = await http.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Response.Redirect("/Administration/TeacherGallery");
                return;
            }
            throw new Exception("Failed to delete teacher");
        }
    }
}