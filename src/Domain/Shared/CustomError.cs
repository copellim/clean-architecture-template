namespace Domain.Shared;

public class CustomError : FluentResults.Error
{
    public string Code { get; }
    public CustomError(string code, string message) : base(message)
    {
        Code = code;
    }
}