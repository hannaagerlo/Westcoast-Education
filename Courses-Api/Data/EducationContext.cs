using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Data
{
        public class EducationContext : IdentityDbContext<Admin>
    {
        public EducationContext(DbContextOptions<EducationContext> options) : base(options){}

        public DbSet<Course> Courses => Set<Course>(); 
        public DbSet<Student> Students => Set<Student>(); 
        public DbSet<Teacher> Teachers => Set<Teacher>(); 
        
    }
    
}