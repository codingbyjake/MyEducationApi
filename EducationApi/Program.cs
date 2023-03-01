using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using EducationApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EducationDbContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("EducationDbContext"));
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


