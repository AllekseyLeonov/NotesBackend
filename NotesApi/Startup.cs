using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.Domain.Interfaces;
using Notes.Infrastructure.Business;
using Notes.Infrastructure.Data;
using Notes.Services.Interfaces;

namespace NotesApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAllHeaders",
          builder =>
          {
            builder.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
          });
      });
      services.AddDbContext<NotesContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddTransient<IUserService, UserService>();
      services.AddTransient<INoteService, NoteService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseCors("AllowAllHeaders");
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}
