using System.Text.Json;
using CustomerInterface.ViewModels;

namespace CustomerInterface.Models
{
    public class TeacherServiceModel
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _config;

        public TeacherServiceModel(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}/teachers";

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<bool> CreateTeacher(CreateTeacherViewModel createTeacher)
        {
            using var http = new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/teachers/";
    
            var response = await http.PostAsJsonAsync(url, createTeacher);

            if (!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
                return false;
            } 

            return true;
        }

        public async Task<List<TeacherViewModel>> ListAllTeachers()
        {
            var url = $"{_baseUrl}";
            using var http = new HttpClient();
            var response = await http.GetAsync(url);
            
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Det gick inge vidare");
            }

            var result = await response.Content.ReadAsStringAsync();
            var teachers = JsonSerializer.Deserialize<List<TeacherViewModel>>(result, _options);
            return teachers ?? new List<TeacherViewModel>();
        }

        public async Task<TeacherViewModel> GetTeacherById(int id)
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/teachers/{id}";

            using var Http = new HttpClient();
            var response = await Http.GetAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Det gick inte att hitta läraren");
            }

            var teacher = await response.Content.ReadFromJsonAsync<TeacherViewModel>();
            return teacher ?? new TeacherViewModel();
        }

        public async Task DeleteTeacher(int id)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Det gick inget vidare");
            }
        }


    }
}

