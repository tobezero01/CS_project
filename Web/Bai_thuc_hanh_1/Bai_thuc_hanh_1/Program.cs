using Bai_thuc_hanh_1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SchoolContext")));


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initalize(services);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
