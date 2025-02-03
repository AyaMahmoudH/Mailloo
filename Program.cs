using Microsoft.EntityFrameworkCore;
using Mailo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Mailo.Models;
using Mailo.IRepo;
using Mailo.Repo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Mailoo.Models;
using Mailoo.IRepo;
using Mailoo.Repo;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IAddToWishlistRepo), typeof(AddToWishlistRepo));
builder.Services.AddScoped(typeof(ICartRepo), typeof(CartRepo));
builder.Services.AddScoped(typeof(ISearchRepo), typeof(SearchRepo));
builder.Services.AddScoped(typeof(IProductRepo), typeof(ProductRepo));

builder.Services.AddScoped<IBasicRepo<Order>, BasicRepo<Order>>();
builder.Services.AddSingleton<PayPalService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    {
    options.LoginPath = "/Account/Login"; // المسار لصفحة تسجيل الدخول
    options.AccessDeniedPath = "/Account/AccessDenied"; // المسار لصفحة رفض الوصول
    options.ExpireTimeSpan = TimeSpan.FromHours(2); // عمر الكوكي
    options.SlidingExpiration = true; // تمديد الجلسة عند النشاط
}); ;
builder.Services.AddScoped<EmailService>();
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});




builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
    options.AddPolicy("EmployeeOnly", policy => policy.RequireRole("Employee"));
});




var app = builder.Build();



app.Use(async (context, next) =>
{
    var user = context.User;
    if (user.Identity.IsAuthenticated)
    {
        Console.WriteLine($"User {user.Identity.Name} is authenticated.");
    }
    else
    {
        Console.WriteLine("User is not authenticated.");
    }
    await next();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints => endpoints.MapRazorPages());


app.Run();