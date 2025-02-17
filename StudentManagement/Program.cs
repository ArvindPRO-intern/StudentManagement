using Microsoft.EntityFrameworkCore;
using StudentManagement.Repository;
using StudentManagement.Repository.Implementation;
using StudentManagement.Repository.Interface;
using StudentManagement.Services;
using StudentManagement.Services.Implementation;
using StudentManagement.Services.Interface;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagement"), b => b.MigrationsAssembly("StudentManagement.Repository")));
builder.Services.AddTransient<IStudentServices, StudentServices>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentMarksServices, StudentMarksServices>();
builder.Services.AddTransient<IStudentMarksRepository, StudentMarksRepository>();
builder.Services.AddTransient<IStudentContactServices, StudentContactServices>();
builder.Services.AddTransient<IStudentContactRepository, StudentContactRepository>();
builder.Services.AddTransient<IStudentReportServices, StudentReportServices>();
builder.Services.AddTransient<IStudentReportRepository, StudentReportRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapping));
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
