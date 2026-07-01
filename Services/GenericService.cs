using Microsoft.EntityFrameworkCore;
using System;
using TestEmployeeManagement.Data;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly ApplicationDBcontext _context;
    private readonly DbSet<T> _dbSet;

    public GenericService(ApplicationDBcontext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        try
        {
            return await ();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching data: {ex.Message}");
        }
    }

    public async Task<T?> GetById(int id)
    {
        try
        {
            return await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching record: {ex.Message}");
        }
    }

    public async Task<T?> GetByEmployeeCode(string code)
    {
        try
        {
            if (typeof(T) == typeof(Employee))
            {
                return await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "EmployeeCode") == code);
            }
            throw new NotSupportedException("GetByEmployeeCode is only supported for Employee entity.");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching record by code: {ex.Message}");
        }
    }

    public async Task<T> Create(T entity)
    {
        try
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating record: {ex.Message}");
        }
    }

    public async Task<bool> Update(int id, T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating record: {ex.Message}");
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting record: {ex.Message}");
        }
    }
}