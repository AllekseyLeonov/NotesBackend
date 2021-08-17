using System.Collections.Generic;
using System.Linq;
using Notes.Domain.Core;
using Notes.Domain.Interfaces;
using Notes.Services.Interfaces;

namespace Notes.Infrastructure.Business
{
  public class NoteService : ServiceConstructor, INoteService
  {
    public NoteService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public List<Note> GetNotes(string userEmail)
    {
      return UnitOfWork.Notes.GetAll()
        .Where(note => note.User.Email == userEmail).ToList();
    }

    public List<Note> GetSharedNotes(string userEmail)
    {
      return UnitOfWork.Notes.Filter(
          note => note.User.Email == userEmail,
          "SharedNotes")
        .ToList();
    }

    public void CreateNote(Note note)
    {
      if (note == null) return;
      UnitOfWork.Notes.Create(note);
      UnitOfWork.Save();
    }

    public void AddSharedNote(string userEmail, int noteId)
    {
      User user = UnitOfWork.Users
        .Filter(userToFind => userToFind.Email == userEmail)
        .FirstOrDefault();
      Note note = UnitOfWork.Notes.Get(noteId);

      user?.SharedNotes.Add(note);
      UnitOfWork.Save();
    }
  }
}
