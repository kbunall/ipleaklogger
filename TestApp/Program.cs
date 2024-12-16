using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var supportedCultures = new List<CultureInfo>
                {

                new CultureInfo("tr-TR")
                };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    DefaultRequestCulture = new RequestCulture("tr-TR")
});

//bool exists = System.IO.Directory.Exists(FileManager.PhysicalPath);
//if (!exists)
//    System.IO.Directory.CreateDirectory(FileManager.PhysicalPath);

//app.UseFileServer(new FileServerOptions
//{
//    FileProvider = new PhysicalFileProvider(FileManager.PhysicalPath),
//    RequestPath = new PathString(FileManager.VirtualPath),
//    EnableDirectoryBrowsing = false
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseCors();
//app.UseAuthorization();
//app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

