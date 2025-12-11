using AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer.Services;
using AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer.Settings;
using Microsoft.Extensions.Options;

namespace AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer;

public static class ServiceCollectionExt
{
    public static void AddAuth0JwtBearerAuthentication(this IServiceCollection services)
    {
        services
            .AddOptions<Auth0JwtBearerAuthenticationSettings>()
            .BindConfiguration(nameof(Auth0JwtBearerAuthenticationSettings))
            .ValidateDataAnnotations();
        
        services.AddSingleton<IAuth0JwtBearerAuthenticationService, Auth0JwtBearerAuthenticationService>();
        
        using var tempServiceProvider = services.BuildServiceProvider();
        var settings = tempServiceProvider.GetRequiredService<IOptions<Auth0JwtBearerAuthenticationSettings>>().Value;
        
        services.AddAuthentication(Auth0JwtBearerAuthenticationSettings.Scheme)
            .AddJwtBearer(Auth0JwtBearerAuthenticationSettings.Scheme, options =>
            {
                options.Authority = settings.Authority;
                options.TokenValidationParameters.ValidAudience = settings.ValidAudience;
                options.TokenValidationParameters.ValidateAudience = true;
                options.TokenValidationParameters.ValidateIssuer = true;
                options.TokenValidationParameters.ValidateActor = true;
                options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                options.TokenValidationParameters.ValidateLifetime = true;
                options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });
    }
}