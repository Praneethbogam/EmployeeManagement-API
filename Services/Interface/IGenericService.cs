using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using TestEmployeeManagement.Data;


public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?>GetByEmployeeCodeAsync(string code); 
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(int id);
}