public interface IDepartmentService
{
    Task<IEnumerable<Departments>> GetAll();
    Task<Departments?> GetById(int id);
    Task<Departments> Create(Departments dept);
    Task<bool> Update(int id, Departments dept);
    Task<bool> Delete(int id);
}