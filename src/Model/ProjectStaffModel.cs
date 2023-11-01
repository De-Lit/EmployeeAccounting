namespace EmployeeAccounting.Model;
public class ProjectStaffModel
{
    [SQLite.PrimaryKey, NotNull, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public int ProjectId { get; set; }
    [NotNull]
    public int StaffId { get; set; }
}