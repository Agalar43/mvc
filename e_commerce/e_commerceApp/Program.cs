using e_commerceApp.Infrastructe.Extensions;
using e_commerceApp.Models;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



builder.Services.AddSession(options =>
{
    options.Cookie.Name = "e_commerceApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("e_commerceApp")
    );
    options.EnableSensitiveDataLogging(true);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;

}).AddEntityFrameworkStores<RepositoryContext>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

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
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages();
});
//UseAuthentication ve UseAuthorization routing ve enpointler arasında olmalı


app.ConfigureDefaultAdminUser();
app.Run();
