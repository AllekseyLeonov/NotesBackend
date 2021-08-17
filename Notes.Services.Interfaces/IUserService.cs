using System.Collections.Generic;
using Notes.Domain.Core;

namespace Notes.Services.Interfaces
{
  public interface IUserService
  {
    void Create(User user);

    User GetUserByEmail(string email);

    bool IsAuthorisationCorrect(string email, string password);
  }
}
