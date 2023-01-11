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
    public class UpdateTeacher : PageModel
    {
        private readonly ILogger<UpdateTeacher> _logger;
        private readonly string _baseUrl;
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        [BindProperty]
        public UpdateTeacherViewModel TeacherModel { get; set; }

        public UpdateTeacher(ILogger<UpdateTeacher> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _baseUrl = _config.GetValue<string>("baseUrl");
            _http = new HttpClient();
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var url = $"{_baseUrl}/teachers/{id}";
            var teacher = await _http.GetFromJsonAsync<TeacherViewModel>(url);
            var teacherToUpdate = new UpdateTeacherViewModel
            {
                TeacherId = teacher.TeacherId,
                Firstname = teacher.Name.Split(" ")[0],
                Lastname = teacher.Name.Split(" ")[1],
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                Street = teacher.Address.Split(" ")[0],
                StreetNumber = teacher.Address.Split(" ")[1],
                PostalCode = teacher.Address.Split(" ")[2],
                City = teacher.Address.Split(" ")[3],
            };

            TeacherModel = teacherToUpdate;
            _http.Dispose();

            return Page();
        }

        public async Task OnPostAsync()
        {
            var url = $"{_baseUrl}/teachers/{TeacherModel.TeacherId}";

            var response = await _http.PutAsJsonAsync(url, TeacherModel);

            if (!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
            Response.Redirect("/Administration/TeacherGallery");
            return;
        }
    }
}