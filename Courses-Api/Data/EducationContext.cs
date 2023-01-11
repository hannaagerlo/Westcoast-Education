using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courses_Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Courses_Api.Data
{
        public class EducationContext : IdentityDbContext<User>
    {
        public EducationContext(DbContextOptions<EducationContext> options) : base(options){}

        public DbSet<Course> Courses => Set<Course>(); 
        public DbSet<User> Users => Set<User>(); 
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Category> Categories => Set<Category>(); 
        public DbSet<Competence> Competences => Set<Competence>(); 
        //public DbSet<Role> Roles => Set<Role>(); 
        public DbSet<StudentCourse> StudentCourse => Set<StudentCourse>(); 
        //  public DbSet<TeacherCourse> TeacherCourse => Set<TeacherCourse>(); 
        //   public DbSet<TeacherCompetence> TeacherCompetence => Set<TeacherCompetence>(); 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

        
        // modelBuilder.Entity<TeacherCourse>()
        //     .HasKey(tc => new { tc.TeacherId, tc.CourseId });
        
        // modelBuilder.Entity<TeacherCompetence>()
        //     .HasKey(tc => new { tc.TeacherId, tc.CompetenceId });
        
        modelBuilder.Entity<User>()
            .Property(a => a.Email)
            .IsRequired();
            
        
    }

    }
    
}