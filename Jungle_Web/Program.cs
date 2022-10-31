using Microsoft.EntityFrameworkCore;
using Jungle_DataAccess;
using Microsoft.AspNetCore.Identity;
using Jungle_Models;
using Jungle_DataAccess.Repository;
using Jungle_DataAccess.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JungleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);




builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<JungleDbContext>().AddDefaultUI();
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 5;
    opt.Password.RequireLowercase = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    opt.Lockout.MaxFailedAccessAttempts = 5;
});


//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddRazorPages();
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
app.UseAuthentication(); ;

app.UseAuthorization();

app.UseEndpoints(endpoints =>
     {
         endpoints.MapControllerRoute(
                    name: "Guide",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

         endpoints.MapControllerRoute(
                     name: "Customer",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

         endpoints.MapControllerRoute(
                     name: "Admin",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

         endpoints.MapControllerRoute(
                    name: "Counselor",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

         //test
         //endpoints.MapControllerRoute(
         //          name: "Users",
         //          pattern: "{controller=User}/{action=Index}");


         endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");



         endpoints.MapRazorPages();
     });

app.Run();
