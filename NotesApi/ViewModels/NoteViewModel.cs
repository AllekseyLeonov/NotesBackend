using Notes.Domain.Core;

namespace NotesApi.ViewModels
{
  public class NoteViewModel
  {
    public string Title { get; set; }
    public string Content { get; set; }
    public string Date { get; set; }

    // TODO: replace with automapper
    public NoteViewModel(Note note)
    {
      Title = note.Title;
      Content = note.Content;
      Date = note.Date;
    }
  }
}
