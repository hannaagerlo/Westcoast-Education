using System.Text.Json;
using CustomerInterface.ViewModels.Student;

namespace CustomerInterface.Models
{
    public class UserHelperServiceModel
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _config;

        public UserHelperServiceModel(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}";

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

         public async Task<StudentViewModel?> LoggedInStudent()
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


