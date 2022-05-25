using Courses_Api.Data;
using Courses_Api.Interface;
using Courses_Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Databas kopplingen
builder.Services.AddDbContext<CourseContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

// Dependacy injection för interface och klasser 
builder.Services.AddScoped<ICoursesRepository, CourseRepository>(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
