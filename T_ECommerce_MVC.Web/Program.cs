using Microsoft.EntityFrameworkCore;
using T_ECommerce_MVC.DataAccess.Data;
using T_ECommerce_MVC.DataAccess.Repository.IRepository;
using T_ECommerce_MVC.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

#region Services
// SERVICES
builder.Services.AddControllersWithViews();

 // Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
