using System.Text.Json;
using CustomerInterface.ViewModels.Student;

namespace CustomerInterface.Models
{
    public class StudentServiceModel
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _config;

        public StudentServiceModel(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}/students";

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

         public async Task<bool> CreateStudent(CreateStudentViewModel register)
        {
            using var http = new HttpClient();
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students/";
    
            var response = await http.PostAsJsonAsync(url, register);

            if (!response.IsSuccessStatusCode)
            {
                string reason = await response.Content.ReadAsStringAsync();
                Console.WriteLine(reason);
                return false;
            }

            return true;
        }
         public async Task<List<StudentViewModel>> ListAllStudents()
        {
            var url = $"{_baseUrl}";
            using var http = new HttpClient();
            var response = await http.GetAsync(url);
            
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Det gick inge vidare");
            }

            var result = await response.Content.ReadAsStringAsync();
            var students = JsonSerializer.Deserialize<List<StudentViewModel>>(result, _options);
            return students ?? new List<StudentViewModel>();
        }

        public async Task<StudentViewModel> GetStudentById(int id)
        {
            var baseUrl = _config.GetValue<string>("baseUrl");
            var url = $"{baseUrl}/students/{id}";

            using var Http = new HttpClient();
            var response = await Http.GetAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Det gick inte att hitta studenten");
            }

            var student = await response.Content.ReadFromJsonAsync<StudentViewModel>();
            return student ?? new StudentViewModel();
        }

        public async Task DeleteStudent(int id)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        public async Task EditStudent(EditStudentViewModel student)
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.PutAsJsonAsync(url, student);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Det gick inte att hitta eleven");
            }            
        }
        public async Task<StudentViewModel?> GetStudent()
        {
            var url = $"{_baseUrl}/getStudent";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Okänt fel");
            }

            var loggedInStudent = await response.Content.ReadFromJsonAsync<StudentViewModel>();

            return loggedInStudent;
        }

        
    }
}