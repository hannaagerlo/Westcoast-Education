using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages.Administration
{
    public class TeacherGallery : PageModel
    {
         private readonly ILogger<TeacherGallery> _logger;
        private readonly IConfiguration _config;

        [BindProperty]
        public List<TeacherViewModel> Teachers { get; set; }
        public TeacherGallery(ILogger<TeacherGallery> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/teachers";

            using var http = new HttpClient();
            Teachers = await http.GetFromJsonAsync<List<TeacherViewModel>>(url);
        }
    }
}
