using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages.Administration
{
    public class CreateCourse : PageModel
    {
        private readonly ILogger<CreateCourse> _logger;

        [BindProperty]
        public CreateCourseViewModel CourseModel { get; set; }
        private readonly IConfiguration _config;

        public CreateCourse(ILogger<CreateCourse> logger, IConfiguration config)
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
            var url = $"{baseUrl}/courses";
            var response = await http.PostAsJsonAsync(url, CourseModel);

            if(!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
        
        }
    }
}
