using FutureGeneration.Data;
using FutureGeneration.Models;
using FutureGeneration.Repository;
using FutureGeneration.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Entites>(e => e
                .UseSqlServer(builder.Configuration.GetConnectionString("FutureGenerationConn"))
                .UseEnumCheckConstraints());

builder.Services.AddScoped<IRepository<Student>, StudentService>();
builder.Services.AddScoped<IRepository<Cource>, CourceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
