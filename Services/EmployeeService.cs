using Microsoft.EntityFrameworkCore;
using System;
using TestEmployeeManagement.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmployeeService : IEmployeeService
{
    private readonly IGenericService<Employee> _generic;
    private readonly ApplicationDBcontext _context;

    public EmployeeService(
        IGenericService<Employee> generic,
        ApplicationDBcontext context)
    {
        _generic = generic;
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        try
        {
            return await _generic.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Employee fetch error: {ex.Message}");
        }
    }

    public async Task<Employee?> GetById(int id)
    {
        try
        {
            return await _generic.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Employee fetch by id error: {ex.Message}");
        }
    }

    public async Task<Employee?> GetByEmployeeCode(string code)
    {
        try
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeCode == code);
        }
        catch (Exception ex)
        {
            throw new Exception($"Employee fetch by code error: {ex.Message}");
        }
    }
    public async Task<Employee> Create(Employee emp)
    {
        try
        {
            if (emp.Salary <= 0)
                throw new Exception("Salary must be greater than 0");

            return await _generic.CreateAsync(emp);
        }
        catch (Exception ex)
        {
            throw new Exception($"Employee creation error: {ex.Message}");
        }
    }

    public async Task<bool> Update(int id, Employee emp)
    {
        try
        {
            return await _generic.UpdateAsync(id, emp);
        }
        catch (Exception ex)
        {
            throw new Exception($"Employee update error: {ex.Message}");
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            return await _generic.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Employee delete error: {ex.Message}");
        }
    }
    //public async Task<IEnumerable<EmployeeDto>> GetWithDepartment()
    //{
    //    try
    //    {
    //        return await _context.Employee
    //            .Include(e => e.Department)
    //            .Select(e => new EmployeeDto
    //            {
    //                EmployeeId = e.EmployeeId,
    //                EmployeeName = e.EmployeeName,
    //                EmployeeCode = e.EmployeeCode,
    //                PhoneNumber = e.PhoneNumber,
    //                Salary = e.Salary,
    //                DepartmentName = e.Department!.Name
    //            })
    //            .ToListAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception($"Join query error: {ex.Message}");
    //    }
    //}
}