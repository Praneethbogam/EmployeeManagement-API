public class Salary
{
    public int SalaryId { get; set; }

    public int EmployeeId { get; set; }

    public decimal Amount { get; set; }

    public DateTime EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public Employee? Employee { get; set; }
}