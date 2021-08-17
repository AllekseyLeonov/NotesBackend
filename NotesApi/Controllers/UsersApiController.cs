using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Core;
using Notes.Services.Interfaces;
using NotesApi.ViewModels;

namespace NotesApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _users;

    public UsersController(IUserService users)
    {
      _users = users;
    }

    [HttpPost]
    public void AddUser(User user)
    {
      _users.Create(user);
    }

    [HttpGet]
    public bool IsUserExist(string email, string password)
    {
      return _users.IsAuthorisationCorrect(email, password);
    }

    [HttpGet]
    public UserViewModel GetUserInfo(string email)
    {
      return new UserViewModel(_users.GetUserByEmail(email));
    }
  }
}
