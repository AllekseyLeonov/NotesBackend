using System.Collections.Generic;
using Notes.Domain.Core;

namespace Notes.Services.Interfaces
{
  public interface INoteService
  {
    List<Note> GetNotes(string userEmail);
    List<Note> GetSharedNotes(string userEmail);
    void CreateNote(Note note);
    void AddSharedNote(string userEmail, int noteId);
  }
}
