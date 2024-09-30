using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebDev_MiniProject.Data;
using WebDev_MiniProject.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RuamtyDB")));

builder.Services.AddIdentity<Account, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false; // ไม่ต้องมีตัวเลข
    options.Password.RequiredLength = 1; // ความยาวขั้นต่ำ 0 (อนุญาตให้เป็นรหัสผ่านว่าง)
    options.Password.RequireLowercase = false; // ไม่ต้องมีตัวพิมพ์เล็ก
    options.Password.RequireNonAlphanumeric = false; // ไม่ต้องมีตัวอักษรพิเศษ
    options.Password.RequireUppercase = false; // ไม่ต้องมีตัวพิมพ์ใหญ่
    options.Password.RequiredUniqueChars = 0; // จำนวนตัวอักษรที่ไม่ซ้ำกันขั้นต่ำเป็น 0
}).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

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

app.UseRouting(); // ต้องอยู่ก่อน UseAuthentication และ UseAuthorization

app.UseAuthentication(); // ตรวจสอบความถูกต้องของผู้ใช้
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomePage}/{id?}");

app.Run();
