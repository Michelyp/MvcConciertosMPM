using MvcConciertosMPM.Helpers;
using MvcConciertosMPM.Models;
using MvcConciertosMPM.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string jsonSecrets = await
    HelperSecretManager.GetSecretsAsync();
KeysModels keysModel =
    JsonConvert.DeserializeObject<KeysModels>(jsonSecrets);
builder.Services.AddSingleton<KeysModels>(x => keysModel);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ServiceApiEventos>();
builder.Services.AddControllersWithViews();
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
