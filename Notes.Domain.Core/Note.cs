using System.Collections.Generic;

namespace Notes.Domain.Core
{
  public class Note
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Date { get; set; }
    public User User { get; set; }
    public List<User> UsersWhoShare { get; set; } = new List<User>();
  }
}
