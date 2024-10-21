using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Restaurant_manager_x_backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Load env
Env.Load();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")));

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