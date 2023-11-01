namespace EmployeeAccounting.Model;
public class ProjectModel
{
    [SQLite.PrimaryKey, NotNull, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string ProjectName { get; set; } = null!;
    public string? ClientName { get; set; }
    public string? PerformerName { get; set; }
}
