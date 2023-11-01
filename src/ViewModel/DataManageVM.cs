using EmployeeAccounting.Model;
using EmployeeAccounting.View;

namespace EmployeeAccounting.ViewModel;

internal class DataManageVM : INotifyPropertyChanged
{
    private List<EmployeeModel> _employeeModels = DataWorker.GetAllEmployees();
    public List<EmployeeModel> EmployeeModels
    {
        get { return _employeeModels; }
        set
        {
            _employeeModels = value;
            NotifyPropertyChanged();
        }
    }
    private List<ProjectModel> _projectModels = DataWorker.GetAllProjects();
    public List<ProjectModel> ProjectModels
    {
        get { return _projectModels; }
        set
        {
            _projectModels = value;
            NotifyPropertyChanged();
        }
    }
    #region COMANDS TO ADD
    public string EmployeeName { get; set; } = null!;
    public string EmployeeSurname { get; set; } = null!;
    public string? EmployeePatronymic { get; set; }
    public string? EmployeeEmail { get; set; }
    private RelayCommand _addNewEmployee;
    public RelayCommand AddNewEmployee
    {
        get
        {
            return _addNewEmployee ?? new RelayCommand(obj =>
            {
                Window wnd = obj as Window;
                var result = DataWorker.CreateEmployee(EmployeeName,
                    EmployeeSurname,
                    EmployeePatronymic,
                    EmployeeEmail);
                UpdateEmloyeeView();
                wnd.Close();
            }
            );
        }
    }
    public string ProjectName { get; set; } = null!;
    public string? ClientName { get; set; }
    public EmployeeModel Performer { get; set; }
    private RelayCommand _addNewProject;
    public RelayCommand AddNewProject
    {
        get
        {
            return _addNewProject ?? new RelayCommand(obj =>
            {
                Window wnd = obj as Window;
                var result = DataWorker.CreateProject(ProjectName,
                    ClientName,
                    Performer.Surname + " " + Performer.Name);
                UpdateEmloyeeView();
                wnd.Close();
            }
            );
        }
    }
    #endregion
    #region COMANDS TO OPEN WINDOW
    private RelayCommand _openAddNewEmployeeWindow;
    public RelayCommand OpenAddNewEmployeeWindow
    {
        get
        {
            return _openAddNewEmployeeWindow ?? new RelayCommand(obj =>
            {
                OpenAddEmployeeWindowMethod();
                UpdateEmloyeeView();
            }
            );
        }
    }
    private RelayCommand _openAddNewProjectWindow;
    public RelayCommand OpenAddNewProjectWindow
    {
        get
        {
            return _openAddNewProjectWindow ?? new RelayCommand(obj =>
            {
                OpenAddProjectWindowMethod();
                UpdateProjectView();
            }
            );
        }
    }
    #endregion
    #region METHODS TO OPEN WINDOW
    private void OpenAddEmployeeWindowMethod()
    {
        AddNewEmployeeWindow newEmployeeWindow = new AddNewEmployeeWindow();
        SetCenterPositionAndOpen(newEmployeeWindow);
    }
    private void OpenAddProjectWindowMethod()
    {
        AddNewProjectWindow newProjectWindow = new AddNewProjectWindow();
        SetCenterPositionAndOpen(newProjectWindow);
    }
    private void SetCenterPositionAndOpen(Window window)
    {
        window.Owner = Application.Current.MainWindow;
        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        window.ShowDialog();
    }
    #endregion
    #region UPDATE VIEWS
    private void UpdateEmloyeeView()
    {
        EmployeeModels = DataWorker.GetAllEmployees();
    }
    private void UpdateProjectView()
    {
        ProjectModels = DataWorker.GetAllProjects();
    }
    #endregion
    #region COMANDS TO DELETE
    public EmployeeModel SelectedEmployee { get; set; }
    private RelayCommand _deleteEmployee;
    public RelayCommand DeleteEmployee
    {
        get
        {
            return _deleteEmployee ?? new RelayCommand(obj =>
            {
                var result = DataWorker.DeleteEmployee(SelectedEmployee);
                UpdateEmloyeeView();
            }
            );
        }
    }
    public ProjectModel SelectedProject { get; set; }
    private RelayCommand _deleteProject;
    public RelayCommand DeleteProject
    {
        get
        {
            return _deleteProject ?? new RelayCommand(obj =>
            {
                var result = DataWorker.DeleteProject(SelectedProject);
                UpdateProjectView();
            }
            );
        }
    }
    #endregion
    public event PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
