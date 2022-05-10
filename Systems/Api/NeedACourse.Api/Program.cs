using Serilog;
using NeedACourse.Api.Configuration;
using NeedACourse.Settings;
using NeedACourse.Api;
using NeedACourse.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((host, cfg)=>
{
    cfg.ReadFrom.Configuration(host.Configuration);
});

var settings = new ApiSettings(new SettingsSource());

// Add services to the container.
var services = builder.Services;
services.AddAppDbContext(settings);
services.AddAppHealthChecks();
services.AddAppVersions();
services.AddAppSettings();
services.AddAppSwagger(settings);
services.AddAppServices();
services.AddAuthentication();
services.AddAuthorization();
services.AddControllers().AddValidator();
services.AddAutoMappers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAppMiddlewares();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.UseAppDbContext();

app.Run();
