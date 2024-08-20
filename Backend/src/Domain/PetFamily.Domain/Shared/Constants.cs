using System.ComponentModel.DataAnnotations;

namespace PetFamily.Domain.Shared;

public class Constants
{
    public const string LINK_REGEX =
        "https?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b([-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)";

    public const string RU_PHONE_REGEX = "(7|8|\\+7)(\\d{3}){2}(\\d{2}){2}";
    
    public const int PHONE_NUMBER_LENGTH = 12;
    public const int LOW_TITLE_LENGTH = 30;
    public const int MEDIUM_TITLE_LENGTH = 60;
    public const int HIGH_TITLE_LENGTH = 100;
    public const int MEDIUM_DESCRIPTION_LENGTH = 150;
    public const int HIGH_DESCRIPTION_LENGTH = 300;
}