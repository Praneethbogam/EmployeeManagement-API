using System.Collections.Generic;
using System.Threading.Tasks;
using TestEmployeeManagement.Data;



public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);

    Task<Employee?> GetByEmployeeCodeAsync(string code);
    Task<Employee> CreateAsync(Employee emp);
    Task<bool> UpdateAsync(int id, Employee emp);
    Task<bool> DeleteAsync(int id);

    // ✅ Custom method
    Task<IEnumerable<EmployeeDto>> WithDepartment { get; }
}