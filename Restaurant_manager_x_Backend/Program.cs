using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Restaurant_manager_x_backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Load env
Env.Load();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
