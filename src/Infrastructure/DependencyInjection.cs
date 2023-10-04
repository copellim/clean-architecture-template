using Application.Abstractions;
using Application.Options;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();
        services.AddDatabaseContext();

        services
            .AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }

    private static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();
        services.AddDbContext<ApplicationDbContext>(
            (sp, OptionsBuilder) =>
            {
                DatabaseOptions? databaseOptions = sp.GetService<IOptions<DatabaseOptions>>()?.Value;
                if (string.IsNullOrWhiteSpace(databaseOptions?.ConnectionString))
                {
                    throw new InvalidOperationException($"Connection string not found.");
                }

                ConvertDomainEventsToOutboxMessagesInterceptor? interceptor
                    = sp.GetRequiredService<ConvertDomainEventsToOutboxMessagesInterceptor>();

                OptionsBuilder.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerAction =>
                {
                    sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                    sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
                })
                .AddInterceptors(interceptor);

                // TODO: Remove this in production
                OptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                OptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            });
        return services;
    }
}
