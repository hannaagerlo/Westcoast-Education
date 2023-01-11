// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.Extensions.Logging;
// using razorApp.ViewModels;

// namespace razorApp.Pages
// {
//     public class Login : PageModel
//     {
//         private readonly ILogger<Login> _logger;
//         private readonly IConfiguration _config;

//         [BindProperty]
// 		public List<LoginViewModel> Students { get; set; }

//         public Login(ILogger<Login> logger, IConfiguration config)
//         {
//             _logger = logger;
//             _config = config;
//         }

//        public async Task OnGet()
//         {
//             // using var http = new HttpClient();

//             // var baseUrl = _config.GetValue<string>("baseUrl");
//             // var url = $"{baseUrl}/students/list";
//             // Students = await http.GetFromJsonAsync<List<StudentViewModel>>(url) ?? new List<StudentViewModel>();
//         }

//         public async Task OnPostAsync(string studentId)
// 		{
// 			if (string.IsNullOrEmpty(studentId))
// 			{
//                 Response.Redirect("/Login");
// 				return;
// 			}
			
// 			var httpClient = new HttpClient();
//             var baseUrl = _config.GetValue<string>("baseUrl");
// 			string url = $"{baseUrl}/Auth/login";
// 			var user = await httpClient.GetFromJsonAsync<LoginViewModel>(url);
// 			if (user == null)
// 				return;

// 			string studentName = $"{user.StudentName}";
// 			HttpContext.Session.SetString("StudentName", studentName);
// 			HttpContext.Session.SetString("StudentId", studentId);
// 			Response.Redirect("/Index");
// 		}
//     }
// }