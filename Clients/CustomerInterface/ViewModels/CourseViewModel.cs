using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerInterface.ViewModels
{
    public class CourseViewModel
    {
        [JsonPropertyName("CourseID")]
        public int CourseId { get; set; } 
        public int CourseNumber { get; set; }   
        public string? Title { get; set; }  
        public string? Lenght { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? ImageUrl { get; set; }
    }
}