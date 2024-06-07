using MercDevs_ej2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MercDevs_ej2.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Conexi�n a la base de datos principal
builder.Services.AddDbContext<MercydevsEjercicio2Context>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("connection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb")));

// Conexi�n al contexto de Identity
builder.Services.AddDbContext<MercDevs_ej2Context>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("connection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.25-mariadb")));

// Configuraci�n de Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MercDevs_ej2Context>()
    .AddDefaultTokenProviders();

// Agregar servicios adicionales
builder.Services.AddRazorPages();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Aseg�rate de agregar esto para usar la autenticaci�n
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
