using System.Collections.Generic;

namespace Notes.Domain.Core
{
  public class User
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public List<Note> SharedNotes { get; set; } = new List<Note>();
  }
}
