using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// TODO Phase 1: Register DAL repositories here (e.g., builder.Services.AddScoped<IGoalRepository, GoalRepository>())
// TODO Phase 1: Register Services here (e.g., builder.Services.AddScoped<IChatService, ChatService>())
// TODO Phase 2: Register BackgroundService for agent scheduling

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
