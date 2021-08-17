using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Core;
using Notes.Services.Interfaces;

namespace NotesApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class NotesApiController : ControllerBase
  {
    private readonly INoteService _noteService;

    public NotesApiController(INoteService noteService)
    {
      _noteService = noteService;
    }

    [HttpGet]
    public List<Note> GetNotes(string userEmail)
    {
      return _noteService.GetNotes(userEmail);
    }

    [HttpGet]
    public List<Note> GetSharedNotes(string userEmail)
    {
      return _noteService.GetSharedNotes(userEmail);
    }

    [HttpPost]
    public void AddNote(Note note)
    {
      _noteService.CreateNote(note);
    }

    [HttpPost]
    public void AddSharedNote(string userEmail, int noteId)
    {
      _noteService.AddSharedNote(userEmail, noteId);
    }
  }
}
