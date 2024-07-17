using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.Data;
using User.Data.Repository;
using User.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("blog");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
    );
builder.Services.AddIdentity<Account, IdentityRole>(
     options =>
     {
         options.Password.RequiredUniqueChars = 0;
         options.Password.RequireUppercase = false;
         options.Password.RequiredLength = 0;
         options.Password.RequireNonAlphanumeric = false;
         options.Password.RequireLowercase = false;
     })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IRepository, Repository>();

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
