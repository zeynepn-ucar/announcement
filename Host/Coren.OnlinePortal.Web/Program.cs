using Coren.OnlinePortal.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMapper();
// Add services to the container.
builder.Services.AddControllersWithViews();
Registration.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}");

app.Run();
