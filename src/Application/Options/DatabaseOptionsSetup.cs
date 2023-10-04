using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Application.Options;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private const string ConfigurationSectionName = "DatabaseOptions";
    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        string? connectionString = _configuration.GetConnectionString("DefaultConnection");
        options.ConnectionString = connectionString ??
            throw new InvalidOperationException($"The connection string DefaultConnection was not found.");
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
