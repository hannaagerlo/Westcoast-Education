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
    public class LoginAdmin : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginModel { get; set; }
        private readonly IConfiguration _config;
        private readonly ILogger<LoginAdmin> _logger;

        public LoginAdmin(ILogger<LoginAdmin> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            using var http = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/auth/login";
            var response = await http.PostAsJsonAsync(url, LoginModel);

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