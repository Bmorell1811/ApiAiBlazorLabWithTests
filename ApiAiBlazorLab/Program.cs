using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ApiAiBlazorLab.Data;
using ApiAiBlazorLab.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Add HttpClient and custom services
builder.Services.AddHttpClient();
builder.Services.AddScoped<CatFactService>();
builder.Services.AddScoped<AiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Bonus: Minimal API endpoint
app.MapGet("/hello", () => "Hello from your API!");

app.Run();
