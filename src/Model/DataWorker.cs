namespace EmployeeAccounting.Model;

public static class DataWorker
{
    public static List<EmployeeModel> GetAllEmployees()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var employees = db.Employees.ToList();
            return employees;
        }
    }
    public static List<ProjectModel> GetAllProjects()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var projects = db.Projects.ToList();
            return projects;
        }
    }
    public static bool CreateEmployee(string name,
        string surname,
        string? patronymic = null,
        string? email = null)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            bool checkIsExist = db.Employees.Any(e => e.Email != null && e.Email == email);
            if (!checkIsExist)
            {
                EmployeeModel employeeModel = new EmployeeModel { Name = name,
                    Patronymic = patronymic,
                    Email = email,
                    Surname = surname
                };
                db.Employees.Add(employeeModel);
                db.SaveChanges();
            }
            return !checkIsExist;
        }
    }

    public static bool CreateProject(string projectName,
        string? clientName = null,
        string? performerName = null)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            bool checkIsExist = db.Projects.Any(e => e.ProjectName == projectName);
            if (!checkIsExist)
            {
                ProjectModel projectModel = new ProjectModel
                {
                    ProjectName = projectName,
                    ClientName = clientName,
                    PerformerName = performerName,
                };
                db.Projects.Add(projectModel);
                db.SaveChanges();
            }
            return !checkIsExist;
        }
    }
    public static bool DeleteEmployee(EmployeeModel employee)
    {
        bool result = false;
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
            result = true;
        }
        return result;
    }
    public static bool DeleteProject(ProjectModel project)
    {
        bool result = false;
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Projects.Remove(project);
            db.SaveChanges();
            result = true;
        }
        return result;
    }
}
