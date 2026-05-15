using BLL.Services;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddControllersWithViews();

//Repo
builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<CropRepo>();
builder.Services.AddScoped<FertilizerRepo>();
builder.Services.AddScoped<SeasonRepo>();
builder.Services.AddScoped<SoilTypeRepo>();
builder.Services.AddScoped<WaterRequirementRepo>();

//Services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CropService>();
builder.Services.AddScoped<FertilizerService>();
builder.Services.AddScoped<SeasonService>();
builder.Services.AddScoped<SoilTypeService>();
builder.Services.AddScoped<WaterRequirementService>();

builder.Services.AddDbContext<AgroGuideMsContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

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
    pattern: "{controller=Crop}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
