public class SalaryDto
{
    public int SalaryId { get; set; }
    public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
}