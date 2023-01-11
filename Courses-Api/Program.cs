using System.Text;
using Courses_Api.Data;
using Courses_Api.Helpers;
using Courses_Api.Helpers.UserHelper;
using Courses_Api.Interface;
using Courses_Api.Models;
using Courses_Api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Databas kopplingen
builder.Services.AddDbContext<EducationContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;

        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = false;

        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    }
).AddEntityFrameworkStores<EducationContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("apiKey"))
        ),
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero

    };
});

// Dependacy injection för interface och klasser 
builder.Services.AddScoped<ICoursesRepository, CourseRepository>(); 
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>(); 
builder.Services.AddScoped<IUserHelper, UserHelper>(); 
builder.Services.AddScoped<IStudentRepository, StudentRepository>(); 
builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>(); 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>(); 


// Add Automapper
builder.Services.AddAutoMapper(typeof(AutoMappersProfiles).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("WestcoastCors",
    policy =>
    {
      policy.AllowAnyHeader();
      policy.AllowAnyMethod();
      policy.WithOrigins(
        "http://localhost:7164");
    }
  );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("WestcoastCors");

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
