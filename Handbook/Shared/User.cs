using System.ComponentModel.DataAnnotations;

namespace Handbook.Shared;

public class User
{
    private const string onlyLettersRegEx = @"^\p{L}+$";
    private const string fieldRequiredMessage = "Обязательное поле.";
    private const string onlyLettersValidateMessage = "Поле должно содержать только буквы.";

    public int Id { get; set; }

    [Required(ErrorMessage = fieldRequiredMessage)]
    [RegularExpression(onlyLettersRegEx, ErrorMessage = onlyLettersValidateMessage)]
    public string FirstName { get; set; } = string.Empty;
   
    [Required(ErrorMessage = fieldRequiredMessage)]
    [RegularExpression(onlyLettersRegEx, ErrorMessage = onlyLettersValidateMessage)]
    public string LastName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = fieldRequiredMessage)]
    [RegularExpression(onlyLettersRegEx, ErrorMessage = onlyLettersValidateMessage)]
    public string Patronymic { get; set; } = string.Empty;
    
    public ActiveDirectoryLogin? ActiveDirectoryLogin { get; set; }
   
    public bool Active { get; set; }
}

