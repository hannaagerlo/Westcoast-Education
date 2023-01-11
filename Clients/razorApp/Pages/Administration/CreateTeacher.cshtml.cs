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
    public class CreateTeacher : PageModel
    {
        [BindProperty]
        public CreateTeacherViewModel TeacherModel { get; set; }
        private readonly ILogger<CreateTeacher> _logger;
        private readonly IConfiguration _config;

        public CreateTeacher(ILogger<CreateTeacher> logger, IConfiguration config)
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
            var url = $"{baseUrl}/teachers";
            var response = await http.PostAsJsonAsync(url, TeacherModel);

            if(!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
            Response.Redirect("/Administration/TeacherGallery");
            return;
        
        }
    }
}
