using TestEmployeeManagement.Models;

public interface ISalaryService
{
    Task<IEnumerable<Salary>> GetAll();
    Task<Salary?> GetById(int id);
    Task<Salary> Create(Salary salary);
    Task<bool> Update(int id, Salary salary);
    Task<bool> Delete(int id);
    Task<IEnumerable<Salary>> GetByEmployee(int employeeId);
    Task<Salary?> GetCurrentSalary(int employeeId);
}