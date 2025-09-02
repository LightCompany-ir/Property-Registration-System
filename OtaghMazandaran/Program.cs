using Microsoft.AspNetCore.Authentication.Cookies;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/admin/login";
        option.LogoutPath = "/";
        option.ExpireTimeSpan = TimeSpan.FromDays(31);
    });
//Local DataBase
builder.Services.AddDbContext<MyContext>(dboption =>
    dboption.UseSqlServer("Server=.;Database=PRS_Db;Integrated Security=true;TrustServerCertificate=True"));
//Remote Database
//builder.Services.AddDbContext<MyContext>(options =>
//    options.UseSqlServer("Server=myserver;Database=mydb;User Id=myUsr;Password=mypass;MultipleActiveResultSets=true;TrustServerCertificate=True;Encrypt=True;")
//);


//builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
