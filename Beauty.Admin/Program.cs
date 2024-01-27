using Beauty.Admin.Models;
using Beauty.Admin;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ManageBeauty>();
builder.Services.AddTransient<ManageAccount>();
builder.Services.AddMvc(); // Add MVC services

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(m =>
{
    m.LoginPath = new Microsoft.AspNetCore.Http.PathString("/home/login");
    m.Cookie.Name = "Beauty_Cookie";

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/login");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
