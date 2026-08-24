namespace WebAPIProject.Repositories.Interfaces;
public interface IGenericRepository<T> where T : class 
{
    Task<IEnumerable<T>> GetAllAsync(); // No devuelve Null - Devuelve un vacio []
    Task<T?> GetByIdAsync(int id); // Puede devolver Null - Si al hacer una consulta (ej. id = 999) no se existe en la BD
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> SaveChangesAsync();

    
}