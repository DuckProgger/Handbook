namespace Handbook.Shared;

public class ActiveDirectoryLogin
{
    public int Id { get; set; }

    /// <summary>
    /// Домен.
    /// </summary>
    public string Domain { get; set; } = string.Empty;

    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; } = string.Empty;
}

