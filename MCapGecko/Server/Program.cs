global using Microsoft.EntityFrameworkCore;
global using MCapGecko.Shared.Models;
global using MCapGecko.Server.Data;
global using MCapGecko.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register DB Context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICoinService, CoinService>();
builder.Services.AddScoped<ICoinGeckoService, CoinGeckoService>();

// Add Hangfire services.
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
.UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

// Add the processing server as IHostedService
builder.Services.AddHangfireServer();

var app = builder.Build();

//swagger
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//swagger
app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseHangfireDashboard("/dashboard");

//ICoinGeckoService CoinGeckoService = app.Services.GetRequiredService<ICoinGeckoService>();

//var scope = app.Services.CreateScope();
//var CoinGeckoService = scope.ServiceProvider.GetService<ICoinGeckoService>();

//RecurringJob.AddOrUpdate("easyjob", () => CoinGeckoService.GetCoinListAsync(), Cron.Hourly);

app.Run();
