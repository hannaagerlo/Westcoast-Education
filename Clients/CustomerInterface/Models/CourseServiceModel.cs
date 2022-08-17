using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CustomerInterface.ViewModels;
using CustomerInterface.ViewModels.Student;

namespace CustomerInterface.Models
{
    public class CourseServiceModel
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _config;

        public CourseServiceModel(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}/courses";

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<CourseViewModel>> ListAllCourses()
        {
            var url = $"{_baseUrl}/list";
            using var http = new HttpClient();
            var response = await http.GetAsync(url);
            
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Det gick inge vidare");
            }

            // var courses = await response.Content.ReadFromJsonAsync<List<CourseViewModel>>();
            var result = await response.Content.ReadAsStringAsync();
            var courses = JsonSerializer.Deserialize<List<CourseViewModel>>(result, _options);
            return courses ?? new List<CourseViewModel>();
        }
        public async Task<CourseViewModel> FindByIdCourse(int id)
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/courses/{id}";

            using var Http = new HttpClient();
            var response = await Http.GetAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Det gick inte att hitta kursen");
            }

            var course = await response.Content.ReadFromJsonAsync<CourseViewModel>();
            return course ?? new CourseViewModel();
        }
        public async Task<List<CourseViewModel>> FindByCategory(string category)
        {

            var url = $"{_baseUrl}/bycategory/{category}";
            using var http = new HttpClient();
            var response = await http.GetAsync(url);
            
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Det gick inge vidare");
            }

            var result = await response.Content.ReadAsStringAsync();
            var courses = JsonSerializer.Deserialize<List<CourseViewModel>>(result, _options);
            return courses ?? new List<CourseViewModel>();
        }
        public async Task<bool> CreateCourse(CreateCourseViewModel course)
        {
            using var http = new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/courses";

            var response = await http.PostAsJsonAsync(url, course);

            if (!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
                return false;
            }

            return true;
        }
        //  public async Task<bool> EditCourse(int id)
        // {
        //    var baseUrl = _config.GetValue<string>("baseUrl");
        //     var url = $"{baseUrl}/courses/{id}";

        //     using var Http = new HttpClient();
        //     var response = await Http.PutAsync(url);

        //     if(!response.IsSuccessStatusCode)
        //     {
        //         Console.WriteLine("Det gick inte att hitta kursen");
        //     }
        //     return true;
        // }

        public async Task<EditCourseViewModel> EditCourse(EditCourseViewModel model)
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.PutAsJsonAsync(url, model);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Det gick inte att hitta kursen");
            }
          

            var course = await response.Content.ReadFromJsonAsync<EditCourseViewModel>();
            return course ?? new EditCourseViewModel();
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/courses/{id}";

            using var Http = new HttpClient();
            var response = await Http.DeleteAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Det gick inte att ta bort kursen");
            }
            return true;
        }

    }

}