using InputBootstrap;
using InputBootstrap.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SigecreDal.Data;
using SigecreNegocio.Repositorios;
using SigecreNegocio.Servicios;
using SigecreNegocio.Servicios2;
using Syncfusion.Blazor;
using Syncfusion.Licensing;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<SeteosDto>();

builder.Services.AddScoped<ISmsServicio, SmsServicio>();
builder.Services.AddScoped<IParametrosServicio2, ParametrosServicio2>();

builder.Services.AddTransient<IParametrosRepositorio, ParametrosRepositorio>();
builder.Services.AddTransient<IComercioRepositorio, ComercioRepositorio>();
builder.Services.AddTransient<IVeriteleServicio, VeriteleServicio>();
builder.Services.AddTransient<INumerarRepositorio, NumerarRepositorio>();
builder.Services.AddTransient<ICodipostServicio, CodipostServicio>();

// bases
builder.Services.AddDbContext<MemoriaContext>(options => options.UseInMemoryDatabase(databaseName: "SiGeCre"));
builder.Services.AddDbContext<CamaraContext>(options => { options.UseMySQL(builder.Configuration.GetConnectionString("camara")); });


var app = builder.Build();

SyncfusionLicenseProvider.RegisterLicense("NjgyNjY3QDMyMzAyZTMyMmUzMEJTakJBUkZieFpPMEtBaktMSU1NS2tyd0dwcmVDRFptOTBpTm0yRnI0RzQ9");



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();

