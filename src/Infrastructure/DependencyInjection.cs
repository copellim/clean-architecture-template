using Infrastructure.Persistence.Interceptors;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    private const string DefaultConnectionStringName = "DefaultConnection";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();
        services.AddDatabaseContext();
        return services;
    }

    private static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        //services.AddDbContext<ApplicationDbContext>(
        //    (sp, OptionsBuilder) =>
        //    {
        //        IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
        //        string? connectionString = configuration.GetConnectionString(DefaultConnectionStringName);
        //        if (string.IsNullOrWhiteSpace(connectionString))
        //        {
        //            throw new InvalidOperationException($"The connection string {DefaultConnectionStringName} was not found.");
        //        }

        //        ConvertDomainEventsToOutboxMessagesInterceptor? interceptor
        //            = sp.GetRequiredService<ConvertDomainEventsToOutboxMessagesInterceptor>();

        //        OptionsBuilder.UseSqlServer(connectionString)
        //            .AddInterceptors(interceptor);
        //    });
        return services;
    }
}
