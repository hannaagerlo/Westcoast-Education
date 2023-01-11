using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages.Administration
{
    public class StudentGallery : PageModel
    {
        private readonly ILogger<StudentGallery> _logger;
        private readonly IConfiguration _config;

        [BindProperty]
        public List<StudentViewModel> Students { get; set; }

        public StudentGallery(ILogger<StudentGallery> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task OnGet()
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students";

            using var http = new HttpClient();
            Students = await http.GetFromJsonAsync<List<StudentViewModel>>(url);
        }
    }
}
