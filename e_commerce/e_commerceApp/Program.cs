using e_commerceApp.Infrastructe.Extensions;
using Microsoft.AspNetCore.Identity;
using Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();

builder.Services.ConfigureApplicationCookie();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;

}).AddEntityFrameworkStores<RepositoryContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();

builder.Services.ConfigureRouting();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseHttpsRedirection();

//UseAuthentication ve UseAuthorization routing ve enpointler arasında olmalı
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});
//UseAuthentication ve UseAuthorization routing ve enpointler arasında olmalı

app.ConfigureAndCheckMigration();
app.ConfigureDefaultAdminUser();
app.ConfigureLocalization();
app.Run();
