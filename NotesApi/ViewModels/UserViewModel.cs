using Notes.Domain.Core;

namespace NotesApi.ViewModels
{
  public class UserViewModel
  {
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }

    // TODO: replace with automapper
    public UserViewModel(User user)
    {
      Email = user.Email;
      FirstName = user.FirstName;
      LastName = user.LastName;
      DateOfBirth = user.DateOfBirth;
    }
  }
}
