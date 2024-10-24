using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Restaurant_manager_x_backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Load env
Env.Load();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Explicitly define the default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapFallbackToController("Index", "Home");
});


app.Run();
