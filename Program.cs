using JobTrackerData.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add user secrets only in development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>(); 
}
// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

//D- injection  Database Configuration

var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings:DatabaseConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string is missing!");
}

builder.Services.AddDbContext<JobTrackerDbContext>(options =>
    options.UseSqlServer(connectionString));

// AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(Program).Assembly); // using AutoMapper;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ApplicationRecordDb API",
        Description = "An ASP.NET Core Web API for track your own Job Applications",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Rohit K Amdahl",
            Url = new Uri("https://rohit-e9f109.netlify.app/")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://github.com/MaaRadha/JobTrackerData/blob/master/LICENSE")
        }
    });

    // Include XML comments for API documentation
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

/*Configure the HTTP request pipeline.*/

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}


app.UseHttpsRedirection();
app.UseRouting(); // Add this line

app.MapControllers();

// Use CORS Errors look my whole file 
app.UseCors(builder => builder
 .AllowAnyHeader()
 .AllowAnyMethod()
 .AllowAnyOrigin()
 );



app.Run();
