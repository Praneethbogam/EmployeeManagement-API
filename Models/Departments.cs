using System.ComponentModel.DataAnnotations;

public class Departments
{
    [Key]
    public int DepartmentId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "";

    [MaxLength(250)]
    public string? Description { get; set; }

    [MaxLength(150)]
    public string? Location { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<Employee>? Employees { get; set; }
}
