using System;
using Notes.Domain.Core;

namespace Notes.Domain.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IGenericRepository<User> Users { get; }
    IGenericRepository<Note> Notes { get; }
    void Save();
  }
}
