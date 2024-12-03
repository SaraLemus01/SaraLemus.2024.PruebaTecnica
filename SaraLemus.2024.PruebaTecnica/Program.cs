using Microsoft.EntityFrameworkCore;
using SaraLemus._2024.pruebaTecnica.DAL;
using SaraLemus._2024.PruebaTecnica.BL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ConexionDB"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexionDB"))));

builder.Services.AddScoped<CategoriaDAL>();
builder.Services.AddScoped<CategoriaBL>();
builder.Services.AddScoped<ProductoDAL>();
builder.Services.AddScoped<ProductoBL>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
