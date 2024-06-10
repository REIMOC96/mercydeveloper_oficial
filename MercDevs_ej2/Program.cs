using MercDevs_ej2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// coneccion a la bdd
builder.Services.AddDbContext <MercydevsEjercicio2Context>(options => 
options.UseMySql(builder.Configuration.GetConnectionString("connection"),
Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb")));
//end bdd

//
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { 
        options.LoginPath = "/Loggeo/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

        
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loggeo}/{action=Login}/{id?}");

app.Run();
