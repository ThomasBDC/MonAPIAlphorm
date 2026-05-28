using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MonAPIAlphorm.BDD;
using MonAPIAlphorm.DTOs;
using MonAPIAlphorm.Services;
using MonAPIAlphorm.Services.Prospect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
   )
);

builder.Services.AddScoped<IProspectService, ProspectService>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateProspectDTOValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
