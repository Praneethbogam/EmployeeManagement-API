using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(100)]
    public string EmployeeName { get; set; } = "";

    [MaxLength(15)]
    public string? PhoneNumber { get; set; }

    [MaxLength(250)]
    public string? Address { get; set; }

    [MaxLength(10)]
    public string? Zipcode { get; set; }

    [MaxLength(20)]
    public string? EmployeeCode { get; set; }

    public decimal? Salary { get; set; }

    public int? DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Departments? Department { get; set; }

    public ICollection<Salary>? Salaries { get; set; }
}