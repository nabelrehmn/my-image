using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;
using Microsoft.AspNetCore.Identity;
using MyImageProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(x =>
        x.UseSqlServer(builder.Configuration.GetConnectionString("Default")
 ));

builder.Services.AddDefaultIdentity<AppUsers>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    // pattern: "{controller=Dashboard}/{action=Index}/{id?}");
    pattern: "{controller=Website}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
