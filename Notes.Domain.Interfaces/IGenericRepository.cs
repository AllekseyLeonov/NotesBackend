using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Notes.Domain.Interfaces
{
  public interface IGenericRepository<T> where T : class
  {
    IList<T> GetAll();
    T Get(int id);
    void Create(T item);
    void Update(T item);
    void Delete(int id);
    IList<T> Filter(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
    Task<T> GetAsync(int id);
    Task<T> CreateAsync(T t);
    Task UpdateAsync(T t);
    Task DeleteAsync(T t);
    Task<IList<T>> GetAllAsync();
    Task<IList<T>> FilterAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
  }
}
