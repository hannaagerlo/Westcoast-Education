using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorApp.ViewModels;
using AutoMapper;

namespace razorApp.Pages.Administration
{
    
    public class UpdateStudent : PageModel
    {
        private readonly ILogger<UpdateStudent> _logger;
        private readonly string _baseUrl;
        private readonly HttpClient _http;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        [BindProperty]
        public UpdateStudentViewModel StudentModel { get; set; }

        public UpdateStudent(ILogger<UpdateStudent> logger, IConfiguration config, IMapper mapper)
        {
            _logger = logger;
            _config = config;
            _mapper = mapper;
            _baseUrl = _config.GetValue<string>("baseUrl");
            _http = new HttpClient();
        }

        // public async Task<IActionResult> OnGetAsync(string id)
        // {
        //     var url = $"{_baseUrl}/students/{id}";
        //     var student = await _http.GetFromJsonAsync<StudentViewModel>(url)
        //      ?? new StudentViewModel();

        //     StudentModel = _mapper.Map<UpdateStudentViewModel>(student);

        //     _http.Dispose();
        //     return Page();
        // }

        
        public async Task<IActionResult> OnGetAsync(string id)
        {
            var url = $"{_baseUrl}/students/{id}";
            var student = await _http.GetFromJsonAsync<StudentViewModel>(url);
            var studentToUpdate = new UpdateStudentViewModel
            {
                Id = student.StudentId,
                FirstName = student.Name.Split(" ")[0],
                LastName = student.Name.Split(" ")[1],
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Street = student.Address.Split(" ")[0],
                StreetNumber = student.Address.Split(" ")[1],
                PostalCode = student.Address.Split(" ")[2],
                City = student.Address.Split(" ")[3],
            };

            StudentModel = studentToUpdate;
            _http.Dispose();

            return Page();
        }

        public async Task OnPostAsync()
        {
            var url = $"{_baseUrl}/students/{StudentModel.Id}";
            var response = await _http.PutAsJsonAsync(url, StudentModel);

            if (!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
            Response.Redirect("/Administration/StudentGallery");
            return;
        }
    }
}
