using Notes.Domain.Interfaces;

namespace Notes.Infrastructure.Business
{
  public class ServiceConstructor
  {
    protected IUnitOfWork UnitOfWork;
    protected ServiceConstructor(IUnitOfWork unitOfWork)
    {
      UnitOfWork = unitOfWork;
    }
  }
}
