using Microsoft.EntityFrameworkCore;
using System;
using TestEmployeeManagement.Data;



public class DepartmentService : IDepartmentService
{
    private readonly IGenericService<Departments> _generic;

    public DepartmentService(IGenericService<Departments> generic)
    {
        _generic = generic;
    }

    public async Task<IEnumerable<Departments>> GetAll()
    {
        try
        {
            return await _generic.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Department fetch error: {ex.Message}");
        }
    }

    public async Task<Departments?> GetById(int id)
    {
        try
        {
            return await _generic.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Department fetch by id error: {ex.Message}");
        }
    }

    public async Task<Departments> Create(Departments dept)
    {
        try
        {
            return await _generic.CreateAsync(dept);
        }
        catch (Exception ex)
        {
            throw new Exception($"Department creation error: {ex.Message}");
        }
    }

    public async Task<bool> Update(int id, Departments dept)
    {
        try
        {
            return await _generic.UpdateAsync(id, dept);
        }
        catch (Exception ex)
        {
            throw new Exception($"Department update error: {ex.Message}");
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
            throw new Exception($"Department delete error: {ex.Message}");
        }
    }
}