using EmployeeAccounting.Model;

namespace EmployeeAccounting
{
    public class ApplicationContext : DbContext
    {
        private static readonly string _connectionString = "Data Source=EAApp.db";
        public DbSet<ProjectModel> Projects { get; set; } = null!;
        public DbSet<EmployeeModel> Employees { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}