using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectingString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FruitkhaDbContext>
    (options => options.UseSqlServer(connectingString));



builder.Services.AddDefaultIdentity<K205User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FruitkhaDbContext>();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/admin/auth/login";
    option.AccessDeniedPath = "/admin/auth/login";
});

builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<INewServices, NewServices>();
builder.Services.AddScoped<IFreshServices, FreshServices>();
builder.Services.AddScoped<IFreeServices, FreeServices>();
builder.Services.AddScoped<IDealServices, DealServices>();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
