namespace Salesforce;

public sealed class LoginResponse(string? serverUrl, string? sessionId)
{
    public string? ServerUrl { get; } = serverUrl;
    public string? SessionId { get; } = sessionId;
}