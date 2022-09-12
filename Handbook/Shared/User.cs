using System.ComponentModel.DataAnnotations;

namespace Handbook.Shared;

public class User
{
    private const string onlyLettersRegEx = @"^\p{L}+$";
    private const string fieldRequiredMessage = "Обязательное поле.";
    private const string onlyLettersValidateMessage = "Поле должно содержать только буквы.";

    public int Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    [Required(ErrorMessage = fieldRequiredMessage)]
    [RegularExpression(onlyLettersRegEx, ErrorMessage = onlyLettersValidateMessage)]
    public string FirstName { get; set; } = string.Empty;
   
    /// <summary>
    /// Фамилия.
    /// </summary>
    [Required(ErrorMessage = fieldRequiredMessage)]
    [RegularExpression(onlyLettersRegEx, ErrorMessage = onlyLettersValidateMessage)]
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>
    /// Отчество.
    /// </summary>
    [Required(ErrorMessage = fieldRequiredMessage)]
    [RegularExpression(onlyLettersRegEx, ErrorMessage = onlyLettersValidateMessage)]
    public string Patronymic { get; set; } = string.Empty;
    
    /// <summary>
    /// Логин Active Directory.
    /// </summary>
    public ActiveDirectoryLogin? ActiveDirectoryLogin { get; set; }
    public int? ActiveDirectoryLoginId { get; set; }
   
    /// <summary>
    /// Статус записи (действующая/недействующая).
    /// </summary>
    public bool Active { get; set; }
}

