using Microsoft.EntityFrameworkCore;
using Notes.Domain.Core;

namespace Notes.Infrastructure.Data
{
  public sealed class NotesContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }

    public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Note>().HasOne(c => c.User);
      modelBuilder.Entity<User>()
        .HasMany(c => c.SharedNotes)
        .WithMany(s => s.UsersWhoShare)
        .UsingEntity(j => j.ToTable("users_to_shared_notes"));
    }
  }
}
