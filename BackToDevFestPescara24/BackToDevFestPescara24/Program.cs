using BackToDevFestPescara24;
using BackToDevFestPescara24.Client.Pages;
using BackToDevFestPescara24.Components;
using BackToDevFestPescara24.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddSingleton<IPokemonService, PokemonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapApi();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BackToDevFestPescara24.Client._Imports).Assembly);

app.Run();