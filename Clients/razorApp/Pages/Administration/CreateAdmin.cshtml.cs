using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages.Administration
{
    public class CreateAdmin : PageModel
    {
        private readonly ILogger<CreateAdmin> _logger;

        [BindProperty]
        public CreateStudentViewModel AdminModel { get; set; }
        private readonly IConfiguration _config;

        public CreateAdmin(ILogger<CreateAdmin> logger, IConfiguration config)
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
            var url = $"{baseUrl}/auth/register";
            var response = await http.PostAsJsonAsync(url, AdminModel);

            if(!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
            
            Response.Redirect("/Administration/Index");
            return;
        
        }
    }
}