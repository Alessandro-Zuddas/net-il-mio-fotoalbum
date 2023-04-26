using IlMioFotalbum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IlMioFotalbum.Areas.Identity.Data;
using FotoContextIdentity = IlMioFotalbum.Areas.Identity.Data.FotoContextIdentity;
using FotoContext = IlMioFotalbum.Models.FotoContext;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FotoContextIdentity>(options =>
    options.UseSqlServer("Data Source=localhost;Initial Catalog=AlbumDb;Integrated Security=True;Pooling=False;TrustServerCertificate = True"));

builder.Services.AddDbContext<FotoContext>(options =>
    options.UseSqlServer("Data Source=localhost;Initial Catalog=AlbumDb;Integrated Security=True;Pooling=False;TrustServerCertificate = True"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FotoContextIdentity>();

// Permette di ignorare il cycling
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Foto}/{action=Index}/{id?}");

app.MapRazorPages();

using (var ctx = new FotoContext())
{
    ctx!.Seed();
}

app.Run();
