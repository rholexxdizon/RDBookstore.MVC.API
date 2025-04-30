using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RDBoookstoreAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("BooksDbConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Books}/{action=Index}/{id?}");

app.MapGet("/", () => Results.Redirect("/api/Books"));

app.Run();
