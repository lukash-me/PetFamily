namespace PetFamily.Domain.Shared;

public class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "value";
            return Error.Validation("value.is.invalid", $"{label} is invalid");
        }

        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for id '{id}'";
            return Error.NotFound("record.not.found", $"record not found{forId}");
        }
        
        public static Error ValueIsRequired(string? name = null)
        {
            var label = name ?? "value";
            return Error.Validation("value.is.required", $"{name} is required");
        }
        
        public static Error InvalidLength(string? name = null)
        {
            var label = name ?? "value";
            return Error.Validation("value.length.is.invalid", $"{name} has invalid length");
        }
        
        public static Error InvalidLink(string? name = null)
        {
            var label = name ?? "link";
            return Error.Validation("link.is.invalid", $"{name} is invalid");
        }
    }
}