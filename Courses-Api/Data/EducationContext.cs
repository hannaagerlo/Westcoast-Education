using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Data
{
        public class EducationContext : DbContext
    {
        public EducationContext(DbContextOptions options) : base(options){}

        public DbSet<Course> Courses => Set<Course>(); 
        public DbSet<Student> Students => Set<Student>(); 
        public DbSet<Teacher> Teachers => Set<Teacher>(); 
        
    }
    
}