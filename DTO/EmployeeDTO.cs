using System.ComponentModel.DataAnnotations;

public class EmployeeDto
{
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(100)]
    public string EmployeeName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? EmployeeCode { get; set; }

    [MaxLength(15)]
    public string? PhoneNumber { get; set; }

    [MaxLength(250)]
    public string? Address { get; set; }

    [MaxLength(10)]
    public string? Zipcode { get; set; }

    public decimal? Salary { get; set; }

    public string? DepartmentName { get; set; }  
}