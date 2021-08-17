using System.Linq;
using Notes.Domain.Core;
using Notes.Domain.Interfaces;
using Notes.Services.Interfaces;

namespace Notes.Infrastructure.Business
{
  public class UserService : ServiceConstructor, IUserService
  {
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public void Create(User user)
    {
      if (user != null)
      {
        UnitOfWork.Users.Create(user);
        UnitOfWork.Save();
      }
    }

    public User GetUserByEmail(string email)
    {
      return UnitOfWork.Users
        .Filter(c => c.Email == email, "SharedNotes")
        .FirstOrDefault();
    }

    public bool IsAuthorisationCorrect(string email, string password)
    {
      return UnitOfWork.Users.GetAll().FirstOrDefault(
        user =>
          user.Email == email &&
          user.Password == password
      ) != null;
    }
  }
}
