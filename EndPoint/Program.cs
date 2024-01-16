using _0_Framework.Application;
using BlogManagement.Infrastructure.Configuration;
using EndPoint;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Configuration;
using ShopManagement.Infrastructure.EFCore.IdentityContext;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

#region Identity
builder.Services.AddDbContext<IdentityDbContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Company")));
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/loginAdmin";
    option.AccessDeniedPath = "/AccessDenied";
    option.SlidingExpiration = true;
});
#endregion

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("Company");
ShopManagementBootstrapper.Configure(builder.Services, connectionString);
BlogManagementBootstrapper.Configure(builder.Services, connectionString);
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IFileUploader, FileUploader>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();

app.Run();
