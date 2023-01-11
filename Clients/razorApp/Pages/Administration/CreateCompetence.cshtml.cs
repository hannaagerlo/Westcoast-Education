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
    public class CreateCompetence : PageModel
    {
         [BindProperty]
        public CreateCompetenceViewModel CompetenceModel { get; set; }
        private readonly IConfiguration _config;
        private readonly ILogger<CreateCompetence> _logger;

        public CreateCompetence(ILogger<CreateCompetence> logger, IConfiguration config)
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
            var url = $"{baseUrl}/competences";
            var response = await http.PostAsJsonAsync(url, CompetenceModel);

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