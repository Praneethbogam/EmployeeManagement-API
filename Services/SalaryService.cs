using Microsoft.EntityFrameworkCore;
using System;
using TestEmployeeManagement.Data;

public class SalaryService : ISalaryService
{
    private readonly IGenericService<Salary> _generic;
    private readonly ApplicationDBcontext _context;

    public SalaryService(
        IGenericService<Salary> generic,
        ApplicationDBcontext context)
    {
        _generic = generic;
        _context = context;
    }

    public async Task<IEnumerable<Salary>> GetAll()
    {
        try
        {
            return await _generic.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Salary fetch error: {ex.Message}");
        }
    }

    public async Task<Salary?> GetById(int id)
    {
        try
        {
            return await _generic.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Salary fetch by id error: {ex.Message}");
        }
    }

    public async Task<Salary> Create(Salary salary)
    {
        try
        {
            // 🔥 deactivate old salary
            var oldSalary = await _context.Salaries
                .Where(s => s.EmployeeId == salary.EmployeeId && s.IsActive)
                .FirstOrDefaultAsync();

            if (oldSalary != null)
            {
                oldSalary.IsActive = false;
                oldSalary.EffectiveTo = DateTime.Now;
            }

            salary.IsActive = true;
            salary.CreatedAt = DateTime.Now;

            return await _generic.CreateAsync(salary);
        }
        catch (Exception ex)
        {
            throw new Exception($"Salary creation error: {ex.Message}");
        }
    }

    public async Task<bool> Update(int id, Salary salary)
    {
        try
        {
            return await _generic.UpdateAsync(id, salary);
        }
        catch (Exception ex)
        {
            throw new Exception($"Salary update error: {ex.Message}");
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
            throw new Exception($"Salary delete error: {ex.Message}");
        }
    }
    public async Task<IEnumerable<Salary>> GetByEmployee(int employeeId)
    {
        return await _context.Salaries
            .Where(s => s.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<Salary?> GetCurrentSalary(int employeeId)
    {
        return await _context.Salaries
            .Where(s => s.EmployeeId == employeeId && s.IsActive)
            .FirstOrDefaultAsync();
    }
}