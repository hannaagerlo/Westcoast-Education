using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorApp.ViewModels;

namespace razorApp.Pages
{
    public class Register : PageModel
    {
        //  private readonly ILogger<Register> _logger;
        private readonly IConfiguration _config;

         [BindProperty]
        public CreateStudentViewModel StudentModel { get; set; } 

        public Register(IConfiguration config)
        {
            _config = config;
            // _logger = logger;
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
            Response.Redirect("/Index");
            return;
        }
    }
}