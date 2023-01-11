
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
        // public async Task OnPostAsync(int courseId)
        // {
        //      using var http = new HttpClient();
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

        //      if(!response.IsSuccessStatusCode)
        //     {
        //         string reason = await response.Content.ReadAsStringAsync();
        //         Console.WriteLine(reason);
        //     }
        //     Response.Redirect("/RegistraionConfirmation");
        //     return;
        // }
        
        
    }
}
