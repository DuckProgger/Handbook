using System.ComponentModel.DataAnnotations;

namespace Handbook.Shared;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public ActiveDirectoryLogin? ActiveDirectoryLogin { get; set; }
}

