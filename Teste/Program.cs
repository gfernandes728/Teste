using Teste.Business.Business;
using Teste.Business.Interface;
using Teste.Infra;
using Teste.Infra.Interface;
using Teste.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<DbDapperContext>();

builder.Services.AddScoped<IAgrupadoresRepository, AgrupadoresRepository>();
builder.Services.AddScoped<IFormularioRepository, FormularioRepository>();
builder.Services.AddScoped<IUtilsRepository, UtilsRepository>();

builder.Services.AddScoped<IAgrupadoresBusiness, AgrupadoresBusiness>();
builder.Services.AddScoped<IFormularioBusiness, FormularioBusiness>();
builder.Services.AddScoped<IUtilsBusiness, UtilsBusiness>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
