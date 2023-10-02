using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFai.Models
{
    [Table("EmployeeTable")]

    public class Employee
    {
        [Key]
        public int eId { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string EmpRole { get; set; } = string.Empty;
        public string EmpEmailAddress { get; set; } = string.Empty;
        public long EmpPhoneNumber { get; set; }
        public string EmpPassword { get; set; } = string.Empty;
    }
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
