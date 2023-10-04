namespace Application.Options;

public class DatabaseOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; set; } = 3;
    public int CommandTimeout { get; set; } = 30;
    public bool EnableDetailedErrors { get; set; } = true;
    public bool EnableSensitiveDataLogging { get; set; } = true;
}
