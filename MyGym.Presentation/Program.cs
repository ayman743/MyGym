using Microsoft.EntityFrameworkCore;
using MyGym.BusinessLogic.Services.Members;
using MyGym.BusinessLogic.Services.Plans;
using MyGym.BusinessLogic.Services.Trainers;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Repositories.Generic;
using MyGym.DataAccess.Repositories.Members;
using MyGym.DataAccess.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GYMDbcontext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IPlanServiece, PlanServiece>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<GYMDbcontext>();
    await DatabaseSeeder.SeedallAsync(context);

}
app.Run();
