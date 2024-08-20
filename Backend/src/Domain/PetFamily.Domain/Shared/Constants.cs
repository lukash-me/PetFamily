namespace PetFamily.Domain.Shared;

public class Constants
{
    public const string LINK_REGEX =
        "https?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b([-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)";
    
    public const int LOW_TITLE_LENGTH = 30;
    public const int MEDIUM_TITLE_LENGTH = 60;
    public const int HIGH_TITLE_LENGTH = 100;
    public const int MEDIUM_DESCRIPTION_LENGTH = 150;
    public const int HIGH_DESCRIPTION_LENGTH = 300;
    
}