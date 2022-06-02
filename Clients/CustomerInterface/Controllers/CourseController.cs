using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CustomerInterface.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerInterface.Controllers
{
    [Route("[controller]")]
    public class CourseController : Controller
    {
        public async Task<IActionResult> Index() 
        {
            var url = "Https://localhost:7164/api/v1/courses/list";
            using var http = new HttpClient();
            var response = await http.GetAsync("");
            
            if(!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Ooops");
            }

            var result = await response.Content.ReadAsStringAsync();
            var courses = JsonSerializer.Deserialize<List<CourseViewModel>>(result);
            return View(); 
        }

    }
}