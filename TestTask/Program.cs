using Microsoft.EntityFrameworkCore;
using TestTask.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContactsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsContext")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}");

app.Run();
