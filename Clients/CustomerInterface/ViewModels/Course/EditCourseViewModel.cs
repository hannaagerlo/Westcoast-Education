using System.ComponentModel.DataAnnotations;

namespace CustomerInterface.ViewModels
{
    public class EditCourseViewModel
    {
        [Required(ErrorMessage = "Kursnamn är obligatoriskt")]
        [Display(Name = "Kursnummer")]
        public int CourseNumber { get; set; }
        [Required(ErrorMessage = "Kursnamn är obligatoriskt")]
        [Display(Name = "Kursnamn")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Längd är obligatoriskt")]
        [Display(Name = "Kurslängd")]
        public string? Lenght { get; set; }
        [Required(ErrorMessage = "Kategori är obligatoriskt")]
        [Display(Name = "Kategori")]
        public string? Category { get; set; }
        [Required(ErrorMessage = "Beskrivning är obligatoriskt")]
        [Display(Name = "Beskrivning av kursen")]
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "Detaljer av bilen är obligatoriskt")]
        [Display(Name = "Detaljer/infomation")]
        public string? Details { get; set; }

        [Required(ErrorMessage = "Bild är obligatoriskt")]
        [Display(Name = "Skicka upp en bild")]
        public string? ImageUrl { get; set; }
    }
}