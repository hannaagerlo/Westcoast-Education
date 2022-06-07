using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
    }
}