using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages.Administration
{
    public class CreateStudent : PageModel
    {
        private readonly ILogger<CreateStudent> _logger;

        [BindProperty]
        public CreateStudentViewModel StudentModel{ get; set; }
        private readonly IConfiguration _config;

        public CreateStudent(ILogger<CreateStudent> logger, IConfiguration config)
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
            var url = $"{baseUrl}/students";
            var response = await http.PostAsJsonAsync(url, StudentModel);

            if(!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
            
            Response.Redirect("/Administration/StudentGallery");
            return;
        
        }
    }
}