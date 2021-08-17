using System;
using Notes.Domain.Core;
using Notes.Domain.Interfaces;

namespace Notes.Infrastructure.Data
{
  public sealed class UnitOfWork : IUnitOfWork
  {
    private readonly NotesContext _db;
    private IGenericRepository<Note> _notesGeneric;
    private IGenericRepository<User> _usersGeneric;
    private bool _disposed;

    public UnitOfWork(NotesContext db)
    {
      _db = db;
    }
    public IGenericRepository<Note> Notes
    {
      get
      {
        if (_notesGeneric == null)
        {
          _notesGeneric = new GenericRepository<Note>(_db);
        }

        return _notesGeneric;
      }
    }

    public IGenericRepository<User> Users
    {
      get
      {
        if (_usersGeneric == null)
        {
          _usersGeneric = new GenericRepository<User>(_db);
        }

        return _usersGeneric;
      }
    }

    public void Save()
    {
      _db.SaveChanges();
    }

    public void Dispose(bool disposing)
    {
      if (!_disposed)
      {
        if (disposing)
        {
          _db.Dispose();
        }
      }

      _disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
