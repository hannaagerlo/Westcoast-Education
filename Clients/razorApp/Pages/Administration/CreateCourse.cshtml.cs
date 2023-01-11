using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razorApp.ViewModels;

namespace razorApp.Pages.Administration
{
    public class CreateCourse : PageModel
    {
        private readonly ILogger<CreateCourse> _logger;

        [BindProperty]
        public CreateCourseViewModel CourseModel { get; set; }
        public SelectList? CategoryModels { get; set; }
        private readonly IConfiguration _config;

        public CreateCourse(ILogger<CreateCourse> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task OnGet()
        {
             using var http = new HttpClient();
             var baseUrl = _config.GetValue<string>("baseUrl");
            string url = $"{baseUrl}/Category/list";
            var categoryModels = await http.GetFromJsonAsync<List<CategoryViewModel>>(url) 
                ?? new List<CategoryViewModel>();

            CategoryModels = new SelectList(categoryModels, nameof(CategoryViewModel.CategoryId),nameof(CategoryViewModel.Category));
        }

        public async Task OnPostAsync(int categoryId)
        {
            using var http = new HttpClient();

            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/courses";
            CourseModel.CategoryId = categoryId;
            var response = await http.PostAsJsonAsync(url, CourseModel);

            if(!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
            }
            Response.Redirect("/Administration/CourseGallery");
            return;
        
        }
    }
}
