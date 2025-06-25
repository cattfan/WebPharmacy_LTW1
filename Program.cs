using Microsoft.EntityFrameworkCore;
using WebPharmacy.Data;
using WebPharmacy.Repositories.Implementations;
using WebPharmacy.Repositories.Interfaces;
using WebPharmacy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Đăng ký ApplicationDbContext với Dependency Injection container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các repository với Dependency Injection container.
builder.Services.AddScoped<IThuocRepository, ThuocRepository>();

// Đăng ký các dịch vụ cần thiết cho việc quản lý Session.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Đăng ký ShoppingCart với Dependency Injection container.
builder.Services.AddScoped(sp => ShoppingCart.GetCart(sp));

// Đăng ký các dịch vụ cần thiết cho Session.
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();