using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Domain.Interfaces;

namespace Notes.Infrastructure.Data
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly NotesContext _context;

    public GenericRepository(NotesContext context)
    {
      _context = context;
    }

    public T Get(int id)
    {
      return _context.Set<T>().Find(id);
    }

    public void Create(T item)
    {
      _context.Set<T>().Add(item);
    }

    public void Update(T item)
    {
      _context.Set<T>().Update(item);
    }

    public void Delete(int id)
    {
      T item = _context.Set<T>().Find(id);
      _context.Set<T>().Remove(item);
    }

    public IList<T> GetAll()
    {
      return _context.Set<T>().ToList();
    }

    public IList<T> Filter(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
    {
      var query = _context.Set<T>().AsQueryable();
      foreach (var navigationProperty in navigationProperties)
      {
        query = query.Include(navigationProperty);
      }
      var list = query.Where(predicate).ToList();
      return list;
    }

    public async Task<T> GetAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T t)
    {
      _context.Set<T>().Add(t);
      await _context.SaveChangesAsync();
      return t;
    }

    public async Task UpdateAsync(T t)
    {
      _context.Set<T>().Update(t);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T t)
    {
      _context.Set<T>().Remove(t);
      await _context.SaveChangesAsync();
    }

    public async Task<IList<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<IList<T>> FilterAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
    {
      var query = _context.Set<T>().AsQueryable();
      foreach (var navigationProperty in navigationProperties)
      {
        query = query.Include(navigationProperty);
      }
      var list = await query.Where(predicate).ToListAsync();
      return list;
    }
  }
}
