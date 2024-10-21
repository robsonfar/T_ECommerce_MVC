using Microsoft.EntityFrameworkCore;
using T_ECommerce_MVC.DataAccess.Data;
using T_ECommerce_MVC.DataAccess.Repository.IRepository;
using T_ECommerce_MVC.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using T_ECommerce_MVC.Util;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

#region Services
// SERVICES
builder.Services.AddControllersWithViews();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Needs to be after adding Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// Add Razor pages for Identity
builder.Services.AddRazorPages();

// Add Stripe for payment
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Facebook Login
builder.Services.AddAuthentication().AddFacebook(option => {
    option.AppId = "193813826680436";
    option.AppSecret = "8fc42ae3f4f2a4986143461d4e2da919";
});

#endregion

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

// Add Stripe for payment
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

// Authentication
app.UseAuthentication();

app.UseAuthorization();

// Session
app.UseSession();

// Add Razor pages for Identity
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
