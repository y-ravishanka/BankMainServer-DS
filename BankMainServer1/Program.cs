using BankMainServer1.Data;
using BankMainServer1.Model;
using BankMainServer1.API;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BankMainServer1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<Database>();
builder.Services.AddSingleton<Calculations>();
builder.Services.AddSingleton<EncryptClass>();
builder.Services.AddHttpClient<ICustomerService, CustomerService>();

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

app.MapBlazorHub();
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
