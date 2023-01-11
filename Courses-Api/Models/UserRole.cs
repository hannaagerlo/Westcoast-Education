using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Courses_Api.Models
{
    public class UserRole
    {   
        public const string Admin = "Admin";
        public const string Teacher = "Teacher";
         public const string Student = "Student";

    }
}