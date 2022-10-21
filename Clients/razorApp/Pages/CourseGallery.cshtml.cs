
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages
{
    public class CourseGallery : PageModel
    {
         private readonly ILogger<CourseGallery> _logger;
        private readonly IConfiguration _config;

        [BindProperty]
        public List<CourseViewModel> Courses { get; set; }
        public CourseGallery(ILogger<CourseGallery> logger, IConfiguration config)
        {
            _config = config;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/courses/list";

            using var http = new HttpClient();
            Courses = await http.GetFromJsonAsync<List<CourseViewModel>>(url);
        }
        public async Task SignUpForCourse()
        {
            
        }
    }
}
