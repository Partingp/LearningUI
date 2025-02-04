using ExperimentalUI.BlazorWebApp.Components;
using ExperimentalUI.BlazorWebApp.Interfaces;
using ExperimentalUI.BlazorWebApp.Models.Options;
using ExperimentalUI.BlazorWebApp.ServiceRegistrations;
using ExperimentalUI.BlazorWebApp.Services;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddFluentUIComponents();

builder.Services.Configure<AnimalEndpointOptions>(builder.Configuration.GetSection(nameof(AnimalEndpointOptions)));

builder.Services.AddTransient(typeof(IRestService<,>), typeof(RestService<,>));

builder.Services.AddViewModels();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
