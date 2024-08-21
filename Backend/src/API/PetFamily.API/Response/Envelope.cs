using PetFamily.Domain.Shared;

namespace PetFamily.API.Response;

public record Envelope
{
    public Envelope(object? result, Error? error)
    {
        Result = result;
        ErrorMessage = error?.Message;
        ErrorCode = error?.Code;
        TimeGenerated = DateTime.Now;
    }
    public object? Result { get; }
    public string? ErrorMessage { get; }
    public string? ErrorCode { get; }
    public DateTime TimeGenerated { get; }

    public static Envelope Ok(object? result = null) => 
        new Envelope(result, null);
    public static Envelope Error(Error error) => 
        new Envelope(null, error);
}