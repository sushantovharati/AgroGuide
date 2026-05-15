using BLL.Services;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Repo
builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<CropRepo>();
builder.Services.AddScoped<FertilizerRepo>();
builder.Services.AddScoped<SeasonRepo>();
builder.Services.AddScoped<SoilTypeRepo>();
builder.Services.AddScoped<WaterRequirementRepo>();
builder.Services.AddScoped<FarmerRepo>();
builder.Services.AddScoped<DivisionRepo>();
builder.Services.AddScoped<DistrictRepo>();
builder.Services.AddScoped<DiseaseRepo>();
builder.Services.AddScoped<AdminRepo>();

//Services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CropService>();
builder.Services.AddScoped<FertilizerService>();
builder.Services.AddScoped<SeasonService>();
builder.Services.AddScoped<SoilTypeService>();
builder.Services.AddScoped<WaterRequirementService>();
builder.Services.AddScoped<FarmerService>();
builder.Services.AddScoped<DivisionService>();
builder.Services.AddScoped<DistrictService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DiseaseService>();

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

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
