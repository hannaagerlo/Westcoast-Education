using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInterface.ViewModels.Student
{
    public class CreateStudentViewModel
    {
    [Required(ErrorMessage = "Förnamn är obligatoriskt")]
    [Display(Name = "Förnamn")]
    public string? Firstname { get; set; }
    [Required(ErrorMessage = "Efternamn är obligatoriskt")]
    [Display(Name = "Efternamn")]
    public string? Lastname { get; set; }
    [Required(ErrorMessage = "E-post är obligatoriskts")]
    [EmailAddress(ErrorMessage ="Felagtig e-post")]
    [Display(Name = "E-post")]
    public string? EmailAdress { get; set; }
    [Required(ErrorMessage = "Telefonnummer är obligatoriskt")]
    [Display(Name = "Telefonnummer")]
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Gatuadress är obligatoriskt")]
    [Display(Name = "Gatuadress")]
    public string? StreetAddress { get; set; }
    
     [Required(ErrorMessage = "Postnummer är obligatoriskt")]
    [Display(Name = "Postnummer")]
    public string? PostalCode { get; set; }

    [Required(ErrorMessage = "Kommun/ort är obligatoriskt")]
    [Display(Name = "Kommun/ort")]
    public string? Municipality { get; set; }

    [Required(ErrorMessage = "Lösenord är obligatoriskt")]
    [Display(Name = "Lösenord")]
    public string? Password { get; set; }

    public bool IsAdmin { get; set; } = false;
    }
}