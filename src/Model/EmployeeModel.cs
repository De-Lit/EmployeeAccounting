namespace EmployeeAccounting.Model;
public class EmployeeModel
{
    [SQLite.PrimaryKey, NotNull, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string Name { get; set; } = null!;
    public string? Patronymic { get; set; }
    [NotNull]
    public string Surname { get; set; } = null!;
    public string? Email {get; set;}
}
